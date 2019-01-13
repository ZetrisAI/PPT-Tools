using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPTTools {
    namespace Modules {
        public abstract class Module {
            public readonly string Identifier;
            private string _filename = "";
            public string filename {
                get { return _filename; }
                set {
                    _filename = value;
                    Properties.Settings.Default[Identifier] = value;
                    Properties.Settings.Default.Save();
                }
            }

            public Module(string identifier) {
                Identifier = identifier;
                filename = (string)Properties.Settings.Default[Identifier];
            }
        }
    }
}
