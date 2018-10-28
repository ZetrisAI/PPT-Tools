using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PPTTools {
    namespace Modules {
        public class Inputs {
            public delegate void InputsEventHandler();
            public event InputsEventHandler Changed;

            private void Raise() {
                if (Changed != null) {
                    
                }
            }

            public void Reset() {


                Raise();
            }

            public void Update() {
                

                Raise();
            }

            public Inputs() {
                Reset();
            }
        }
    }
}