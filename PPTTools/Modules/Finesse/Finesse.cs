using System;
using System.Collections.Generic;
using System.Linq;

namespace PPTTools {
    namespace Modules {
        public class Finesse {
            private int[] keyStates = new int[7] { 0, 0, 0, 0, 0, 0, 0 }, queue = new int[5];
            private List<int> finesseKeys = new List<int>();
            private bool holdUsed, register = false, door = false, holdPressed = false;
            private int? cPiece, cHold;
            private int keystrokes, state, cPiecePos, cPieceRot, errors, piece, holdPtr = GameHelper.HoldPointer(GameHelper.GameState.playerIndex);

            public delegate void FinesseEventHandler(int Errors, int? piece, int? hold, int pos, int rot, bool holdused, int holdPtr);
            public event FinesseEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(errors, cPiece, cHold, cPiecePos, cPieceRot, holdUsed, GameHelper.HoldPointer(GameHelper.GameState.playerIndex));
                }
            }

            public void Reset() {
                keystrokes = errors = state = 0;
                holdPtr = GameHelper.HoldPointer(GameHelper.GameState.playerIndex);
                cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                cHold = null;
                holdUsed = false;
                holdPressed = false;
                queue = new int[5];
                piece = 255;
                register = door = false;

                Raise();
            }

            public void Update() {
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop == 1) {
                    if (drop != state) {
                        if (cPiece != null) {
                            errors += FinesseHelper.Errors(cPiece.Value, finesseKeys, cPiecePos, cPieceRot);
                        }

                        finesseKeys.Clear();
                        holdUsed = false;
                        cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);

                        register = true;
                        door = false;
                        holdPressed = false;
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
                                    if (i != 2 && i != 3 && i != 6) {
                                        finesseKeys.Add(i);
                                    }

                                    if (i == 6) {
                                        holdPressed = true;
                                    }
                                }

                                keyStates[i] = key;
                            }
                        }
                    }

                    piece = current;

                    if (!register)
                        queue = (int[])cQueue.Clone();

                    int cHoldPtr = GameHelper.HoldPointer(GameHelper.GameState.playerIndex);

                    if (cHoldPtr > 0x08000000) { 
                        if (!holdUsed && cHoldPtr != holdPtr && holdPtr > 0x08000000 && holdPressed) {

                            finesseKeys.Clear();
                            holdUsed = true;

                            if (cHold == null) {
                                cHold = cPiece;
                                cPiece = GameHelper.CurrentPiece(GameHelper.GameState.playerIndex);
                            } else {
                                int temp = cHold.Value;
                                cHold = cPiece;
                                cPiece = temp;
                            }
                        }

                        holdPtr = cHoldPtr;
                    }
                }

                state = drop;

                cPiecePos = GameHelper.PiecePosition(GameHelper.GameState.playerIndex);
                cPieceRot = GameHelper.PieceRotation(GameHelper.GameState.playerIndex);

                Raise();
            }

            public Finesse() {
                Reset();
            }
        }
    }
}