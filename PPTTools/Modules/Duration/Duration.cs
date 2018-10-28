using System;

namespace PPTTools {
    namespace Modules {
        public class Duration {
            int frames;

            public delegate void DurationEventHandler(string Time);
            public event DurationEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(new TimeSpan((long)(frames * 166666.6666666667)).ToString("mm':'ss'.'fff"));
                }
            }

            public void Reset() {
                frames = 0;
                Raise();
            }

            public void Update() {
                frames = GameHelper.SmallFrames();
                Raise();
            }

            public Duration() {
                Reset();
            }
        }
    }
}