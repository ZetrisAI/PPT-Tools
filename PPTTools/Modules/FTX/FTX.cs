using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PPTTools {
    namespace Modules {
        public class FTX {
            private int[] score, total;

            public delegate void FTXEventHandler(int[] Score);
            public event FTXEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(total);
                }
            }

            public void Reset() {
                score = new int[2] { 0, 0 };
                total = new int[2] { 0, 0 };

                Raise();
            }

            public void Update() {
                if (GameHelper.EnsureMatch()) {
                    for (int i = 0; i < 2; i++) {
                        int temp = GameHelper.Score(i);

                        if (temp > score[i])
                            total[i]++;

                        score[i] = temp;
                    }

                    Raise();

                } else {
                    Reset();
                }
            }

            public FTX() {
                Reset();
            }
        }
    }
}