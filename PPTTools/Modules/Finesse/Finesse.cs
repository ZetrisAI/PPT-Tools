using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPTTools {
    namespace Modules {
        public class Finesse: Module {
            private static readonly string ModuleIdentifier = "finesse";

            private int[] keyStates = new int[7] { 0, 0, 0, 0, 0, 0, 0 }, queue;
            private List<int> finesseKeys = new List<int>();

            private bool register, door;
            private int errors, cPiece, cPiecePos, cPieceRot, state, holdPtr, piece;
            private int? cHold;

            public delegate void FinesseEventHandler(int Errors);
            public event FinesseEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(errors);
                }
            }

            public void Reset() {
                errors = state = 0;
                holdPtr = GameHelper.HoldPointer(GameHelper.GameState.playerIndex);
                cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                cHold = GameHelper.FarPiece(GameHelper.GameState.playerIndex);
                queue = new int[5];
                piece = 255;
                register = true;
                door = false;

                Raise();
            }

            public void Update() {
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop == 1) {
                    if (drop != state) {
                        int hold = GameHelper.HoldPointer(GameHelper.GameState.playerIndex);

                        errors += FinesseHelper.Errors((holdPtr == hold)? cPiece : cHold.Value, finesseKeys, cPiecePos, cPieceRot);

                        finesseKeys.Clear();
                        cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                        cHold = (hold < 0x0800000)? GameHelper.FarPiece(GameHelper.GameState.playerIndex) : GameHelper.HoldPiece(GameHelper.GameState.playerIndex);
                        holdPtr = hold;

                        register = true;
                    }
                } else {
                    int current = GameHelper.CurrentPiece(GameHelper.GameState.playerIndex);
                    int piecesAddress = GameHelper.NextPointer(GameHelper.GameState.playerIndex);
                    int[] cQueue = new int[5];
                    for (int i = 0; i < 5; i++) {
                        cQueue[i] = GameHelper.Game.ReadByte(new IntPtr(piecesAddress + i * 0x04));
                    }

                    if ((register && !cQueue.SequenceEqual(queue) && current == queue[0]) || (current != piece && piece == 255)) {
                        door = true;
                        register = false;
                    }

                    if (door) {
                        for (int i = 0; i < 7; i++) {
                            int key = GameHelper.Keystroke(i);

                            if (key != keyStates[i]) {
                                if (key == 1 && GameHelper.BigFrames() >= 147) {
                                    if (i != 2 && i != 3) {
                                        finesseKeys.Add(i);
                                    }
                                }

                                keyStates[i] = key;
                            }
                        }
                    }

                    piece = current;

                    if (!register)
                        queue = (int[])cQueue.Clone();
                }

                state = drop;

                cPiecePos = GameHelper.PiecePosition(GameHelper.GameState.playerIndex);
                cPieceRot = GameHelper.PieceRotation(GameHelper.GameState.playerIndex);

                Raise();
            }

            public Finesse(): base(ModuleIdentifier) {
                Reset();
                Changed += Write;
            }

            private void Write(int errors) {
                if (File.Exists(filename)) {
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine($"Finesse: {errors.ToString()}");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}