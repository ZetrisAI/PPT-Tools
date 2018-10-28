using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PPTTools {
    namespace Modules {
        public class APM {
            private int current, total, frames;

            public delegate void APMEventHandler(Decimal APM);
            public event APMEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    if (frames == 0) {
                        Changed.Invoke(0);
                    } else {
                        Changed.Invoke(Decimal.Divide(total, frames) * 3600);
                    }
                }
            }

            public void Reset() {
                total = 0;

                Raise();
            }

            public void Update() {
                frames = GameHelper.SmallFrames();
                int garbage = GameHelper.GarbageSent(GameHelper.GameState.playerIndex);

                if (garbage != current) {
                    if (garbage > current) {
                        total += garbage - current;
                    }

                    current = garbage;
                }

                Raise();
            }

            public APM() {
                Reset();
            }
        }
    }
}