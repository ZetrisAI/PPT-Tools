using System.Collections.Generic;

namespace PPTTools {
    namespace Modules {
        public class Finesse {
            private int[] keyStates = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            private List<int> finesseKeys = new List<int>();
            private bool holdUsed;
            private int? cPiece, cHold;
            private int keystrokes, state, cPiecePos, cPieceRot, errors;

            public delegate void FinesseEventHandler(int Errors);
            public event FinesseEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(errors);
                }
            }

            public void Reset() {
                keystrokes = errors = state = 0;
                cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                cHold = null;
                holdUsed = false;

                Raise();
            }

            public void Update() {
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop == 1) {
                    if (drop != state) {
                        if (cPiece != null) {
                            errors += FinesseHelper.Errors(cPiece.Value, finesseKeys, cPiecePos, cPieceRot, cHold);
                        }

                        finesseKeys.Clear();
                        holdUsed = false;
                        cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                    }
                } else {
                    for (int i = 0; i < 7; i++) {
                        int key = GameHelper.Keystroke(i);

                        if (key != keyStates[i]) {
                            if (key == 1 && GameHelper.BigFrames() >= 147) {
                                if (i == 6 && !holdUsed) {
                                    finesseKeys.Clear();
                                    holdUsed = true;

                                    if (cHold == null) {
                                        cHold = cPiece;
                                        cPiece = GameHelper.NextPiece(GameHelper.GameState.playerIndex);
                                    } else {
                                        int temp = cHold.Value;
                                        cHold = cPiece;
                                        cPiece = temp;
                                    }
                                }

                                if (i != 2 && i != 3 && i != 6) {
                                    finesseKeys.Add(i);
                                }
                            }

                            keyStates[i] = key;
                        }
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