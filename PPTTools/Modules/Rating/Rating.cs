namespace PPTTools {
    namespace Modules {
        public class Rating {
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

            public Rating() {
                Reset();
            }
        }
    }
}