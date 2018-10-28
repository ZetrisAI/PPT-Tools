using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PPTTools {
    namespace Modules {
        public class KPP {
            private int[] keyStates = new int[7] {0, 0, 0, 0, 0, 0, 0};
            private int keystrokes, state, pieces;

            public delegate void KPPEventHandler(Decimal KPP);
            public event KPPEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (pieces == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(keystrokes, pieces));
                    }
                }
            }

            public void Reset() {
                keystrokes = pieces = 0;

                Raise();
            }

            public void Update() {
                int drop = GameHelper.PieceDropped(GameHelper.GameState.playerIndex);

                if (drop != state) {
                    if (drop == 1)
                        pieces++;

                    state = drop;
                }

                for (int i = 0; i < 7; i++) {
                    int key = GameHelper.Keystroke(i);

                    if (key != keyStates[i]) {
                        if (key == 1 && GameHelper.BigFrames() >= 147)
                            keystrokes++;

                        keyStates[i] = key;
                    }
                }

                Raise();
            }

            public KPP() {
                Reset();
            }
        }
    }
}