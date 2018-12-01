using System;
using System.IO;

namespace PPTTools {
    namespace Modules {
        public class Duration: Module {
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
                Changed += Write;
            }

            private void Write(string time) {
                if (File.Exists(filename)) {
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine(time);
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}