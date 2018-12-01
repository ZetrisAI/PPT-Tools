using System;
using System.Collections.Generic;
using System.Linq;

namespace PPTTools {
    class FinesseHelper {
        private static readonly List<int>[][][] finesse = new List<int>[7][][] {
            new List<int>[2][] { // S
                new List<int>[8] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                },
                new List<int>[9] { // Orientation B
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {5, 1}),
                    new List<int>(new int[] {5, 1, 1}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {5, 1})
                }
            },
            new List<int>[2][] { // Z
                new List<int>[8] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                },
                new List<int>[9] { // Orientation B
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {5, 1}),
                    new List<int>(new int[] {5, 1, 1}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {5, 1})
                }
            },
            new List<int>[4][] { // J
                new List<int>[8] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                },
                new List<int>[9] { // Orientation C
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {5, 0, 0}),
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {5, 1}),
                    new List<int>(new int[] {5, 1, 1}),
                    new List<int>(new int[] {5, 1, 0}),
                    new List<int>(new int[] {5, 1})
                },
                new List<int>[8] { // Orientation D
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {0, 0, 4, 4}),
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {4, 4}),
                    new List<int>(new int[] {1, 4, 4}),
                    new List<int>(new int[] {1, 1, 4, 4}),
                    new List<int>(new int[] {1, 0, 4, 4}),
                    new List<int>(new int[] {1, 4, 4})
                },
                new List<int>[9] { // Orientation B
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4, 0, 0}),
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {4, 1}),
                    new List<int>(new int[] {4, 1, 1}),
                    new List<int>(new int[] {1, 0, 4}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {4, 1})
                }
            },
            new List<int>[4][] { // L
                new List<int>[8] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                },
                new List<int>[9] { // Orientation B
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {5, 0, 0}),
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {5, 1}),
                    new List<int>(new int[] {5, 1, 1}),
                    new List<int>(new int[] {5, 1, 0}),
                    new List<int>(new int[] {5, 1})
                },
                new List<int>[8] { // Orientation D
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {0, 0, 4, 4}),
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {4, 4}),
                    new List<int>(new int[] {1, 4, 4}),
                    new List<int>(new int[] {1, 1, 4, 4}),
                    new List<int>(new int[] {1, 0, 4, 4}),
                    new List<int>(new int[] {1, 4, 4})
                },
                new List<int>[9] { // Orientation C
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4, 0, 0}),
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {4, 1}),
                    new List<int>(new int[] {4, 1, 1}),
                    new List<int>(new int[] {1, 0, 4}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {4, 1})
                }
            },
            new List<int>[4][] { // T
                new List<int>[8] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                },
                new List<int>[9] { // Orientation B
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {5, 0, 0}),
                    new List<int>(new int[] {5, 0}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {5, 1}),
                    new List<int>(new int[] {5, 1, 1}),
                    new List<int>(new int[] {5, 1, 0}),
                    new List<int>(new int[] {5, 1})
                },
                new List<int>[8] { // Orientation D
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {0, 0, 4, 4}),
                    new List<int>(new int[] {0, 4, 4}),
                    new List<int>(new int[] {4, 4}),
                    new List<int>(new int[] {1, 4, 4}),
                    new List<int>(new int[] {1, 1, 4, 4}),
                    new List<int>(new int[] {1, 0, 4, 4}),
                    new List<int>(new int[] {1, 4, 4})
                },
                new List<int>[9] { // Orientation C
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4, 0, 0}),
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {4, 1}),
                    new List<int>(new int[] {4, 1, 1}),
                    new List<int>(new int[] {1, 0, 4}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {4, 1})
                }
            },
            new List<int>[1][] { // O
                new List<int>[9] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 1}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1, 0}),
                    new List<int>(new int[] {1})
                }
            },
            new List<int>[2][] { // I
                new List<int>[7] { // Orientation A
                    new List<int>(new int[] {0}),
                    new List<int>(new int[] {0, 0}),
                    new List<int>(new int[] {0}),
                    new List<int>(),
                    new List<int>(new int[] {1}),
                    new List<int>(new int[] {1, 1}),
                    new List<int>(new int[] {1})
                },
                new List<int>[10] { // Orientation B
                    new List<int>(new int[] {4, 0}),
                    new List<int>(new int[] {0, 4}),
                    new List<int>(new int[] {0, 5}),
                    new List<int>(new int[] {0, 4}),
                    new List<int>(new int[] {4}),
                    new List<int>(new int[] {5}),
                    new List<int>(new int[] {1, 5}),
                    new List<int>(new int[] {1, 4}),
                    new List<int>(new int[] {1, 5}),
                    new List<int>(new int[] {5, 1})
                }
            }
        };

        public static int Errors(int piece, List<int> keys, int pos, int rot) {
            keys = keys.Skip(keys.IndexOf(6) + 1).ToList();
            keys.RemoveAll(x => x == 6);
            
            int orient = rot; // L, J, T
            int placement = pos;

            switch (piece) {
                case 0: // S
                case 1: // Z
                case 6: // I
                    orient = rot % 2;
                    break;

                case 5: // O
                    orient = 0;
                    break;
            }

            switch (piece) {
                case 0: // S
                case 1: // Z
                case 2: // J
                case 3: // L
                case 4: // T
                    if (rot != 1)
                        placement--;
                    break;

                case 5: // O
                    if (rot > 2)
                        placement--;
                    break;

                case 6: // I
                    if (rot == 0)
                        placement--;
                    if (rot == 2)
                        placement += -2;
                    break;
            }

            return Math.Max(0, keys.Count - finesse[piece][orient][placement].Count);
        }
    }
}
