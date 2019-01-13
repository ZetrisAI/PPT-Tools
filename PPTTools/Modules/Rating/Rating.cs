using System.IO;

namespace PPTTools {
    namespace Modules {
        public class Rating: Module {
            private static readonly string ModuleIdentifier = "rating";

            private int start, current;

            public delegate void RatingEventHandler(int StartRating, int CurrentRating);
            public event RatingEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(start, current);
                }
            }

            public void Reset() {
                start = current = GameHelper.Rating();
                Raise();
            }

            public void Update() {
                int rating = GameHelper.Rating();

                if (rating != current)
                    current = rating;

                Raise();
            }

            public Rating(): base(ModuleIdentifier) {
                Reset();
                Changed += Write;
            }

            private void Write(int start, int current) {
                if (File.Exists(filename)) {
                    StreamWriter sw = new StreamWriter(filename);
                    sw.WriteLine($"{start} > {current}");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
    }
}