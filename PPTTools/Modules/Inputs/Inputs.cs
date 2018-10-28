namespace PPTTools {
    namespace Modules {
        public class Inputs {
            private int[] keyStates = new int[7] {0, 0, 0, 0, 0, 0, 0};

            public delegate void InputsEventHandler(int[] keyStates);
            public event InputsEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    Changed.Invoke(keyStates);
                }
            }

            public void Reset() {
                Raise();
            }

            public void Update() {
                for (int i = 0; i < 7; i++)
                    keyStates[i] = GameHelper.Keystroke(i);

                Raise();
            }

            public Inputs() {
                Reset();
            }
        }
    }
}