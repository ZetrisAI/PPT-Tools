using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPTTools {
    class FinesseHelper {
        private static readonly List<int>[][][][] finesse = new List<int>[7][][][] {
            new List<int>[2][][] { // S
                new List<int>[8][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 7
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[9][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[5] { // 2
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4}),
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 4
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 7
                        new List<int>(new int[] {5, 1, 1}),
                        new List<int>(new int[] {1, 5, 1}),
                        new List<int>(new int[] {1, 1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                }
            },
            new List<int>[2][][] { // Z
                new List<int>[8][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 7
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[9][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[5] { // 2
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4}),
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 4
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 7
                        new List<int>(new int[] {5, 1, 1}),
                        new List<int>(new int[] {1, 5, 1}),
                        new List<int>(new int[] {1, 1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                }
            },
            new List<int>[4][][] { // J
                new List<int>[8][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 7
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[9][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[6] { // 2
                        new List<int>(new int[] {4, 0, 0}),
                        new List<int>(new int[] {0, 4, 0}),
                        new List<int>(new int[] {0, 0, 4}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 4
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4})
                    },
                    new List<int>[6] { // 6
                        new List<int>(new int[] {4, 1, 1}),
                        new List<int>(new int[] {1, 4, 1}),
                        new List<int>(new int[] {1, 1, 4}),
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 7
                        new List<int>(new int[] {1, 0, 4}),
                        new List<int>(new int[] {0, 4})
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    }
                },
                new List<int>[8][] { // Orientation D
                    new List<int>[8] { // 1
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 2
                        new List<int>(new int[] {0, 0, 4, 4}),
                        new List<int>(new int[] {0, 4, 0, 4}),
                        new List<int>(new int[] {4, 0, 0, 4}),
                        new List<int>(new int[] {0, 4, 4, 0}),
                        new List<int>(new int[] {4, 0, 4, 0}),
                        new List<int>(new int[] {4, 4, 0, 0}),
                        new List<int>(new int[] {0, 0, 5, 5}),
                        new List<int>(new int[] {0, 5, 0, 5}),
                        new List<int>(new int[] {5, 0, 0, 5}),
                        new List<int>(new int[] {0, 5, 5, 0}),
                        new List<int>(new int[] {5, 0, 5, 0}),
                        new List<int>(new int[] {5, 5, 0, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 3
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[2] { // 4
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 5
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 6
                        new List<int>(new int[] {1, 1, 4, 4}),
                        new List<int>(new int[] {1, 4, 1, 4}),
                        new List<int>(new int[] {4, 1, 1, 4}),
                        new List<int>(new int[] {1, 4, 4, 1}),
                        new List<int>(new int[] {4, 1, 4, 1}),
                        new List<int>(new int[] {4, 4, 1, 1}),
                        new List<int>(new int[] {1, 1, 5, 5}),
                        new List<int>(new int[] {1, 5, 1, 5}),
                        new List<int>(new int[] {5, 1, 1, 5}),
                        new List<int>(new int[] {1, 5, 5, 1}),
                        new List<int>(new int[] {5, 1, 5, 1}),
                        new List<int>(new int[] {5, 5, 1, 1}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 7
                        new List<int>(new int[] {1, 0, 4, 4}),
                        new List<int>(new int[] {1, 4, 0, 4}),
                        new List<int>(new int[] {1, 4, 4, 0}),
                        new List<int>(new int[] {1, 0, 5, 5}),
                        new List<int>(new int[] {1, 5, 0, 5}),
                        new List<int>(new int[] {1, 5, 5, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    }
                },
                new List<int>[9][] { // Orientation C
                    new List<int>[3] { // 1
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 3
                        new List<int>(new int[] {5, 0, 0}),
                        new List<int>(new int[] {0, 5, 0}),
                        new List<int>(new int[] {0, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 4
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 7
                        new List<int>(new int[] {5, 1, 1}),
                        new List<int>(new int[] {1, 5, 1}),
                        new List<int>(new int[] {1, 1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {5, 1, 0}),
                        new List<int>(new int[] {1, 5, 0}),
                        new List<int>(new int[] {1, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                }
            },
            new List<int>[4][][] { // L
                new List<int>[8][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 7
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[9][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 3
                        new List<int>(new int[] {5, 0, 0}),
                        new List<int>(new int[] {0, 5, 0}),
                        new List<int>(new int[] {0, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 4
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 7
                        new List<int>(new int[] {5, 1, 1}),
                        new List<int>(new int[] {1, 5, 1}),
                        new List<int>(new int[] {1, 1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {5, 1, 0}),
                        new List<int>(new int[] {1, 5, 0}),
                        new List<int>(new int[] {1, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                },
                new List<int>[8][] { // Orientation D
                    new List<int>[8] { // 1
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 2
                        new List<int>(new int[] {0, 0, 4, 4}),
                        new List<int>(new int[] {0, 4, 0, 4}),
                        new List<int>(new int[] {4, 0, 0, 4}),
                        new List<int>(new int[] {0, 4, 4, 0}),
                        new List<int>(new int[] {4, 0, 4, 0}),
                        new List<int>(new int[] {4, 4, 0, 0}),
                        new List<int>(new int[] {0, 0, 5, 5}),
                        new List<int>(new int[] {0, 5, 0, 5}),
                        new List<int>(new int[] {5, 0, 0, 5}),
                        new List<int>(new int[] {0, 5, 5, 0}),
                        new List<int>(new int[] {5, 0, 5, 0}),
                        new List<int>(new int[] {5, 5, 0, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 3
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[2] { // 4
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 5
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 6
                        new List<int>(new int[] {1, 1, 4, 4}),
                        new List<int>(new int[] {1, 4, 1, 4}),
                        new List<int>(new int[] {4, 1, 1, 4}),
                        new List<int>(new int[] {1, 4, 4, 1}),
                        new List<int>(new int[] {4, 1, 4, 1}),
                        new List<int>(new int[] {4, 4, 1, 1}),
                        new List<int>(new int[] {1, 1, 5, 5}),
                        new List<int>(new int[] {1, 5, 1, 5}),
                        new List<int>(new int[] {5, 1, 1, 5}),
                        new List<int>(new int[] {1, 5, 5, 1}),
                        new List<int>(new int[] {5, 1, 5, 1}),
                        new List<int>(new int[] {5, 5, 1, 1}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 7
                        new List<int>(new int[] {1, 0, 4, 4}),
                        new List<int>(new int[] {1, 4, 0, 4}),
                        new List<int>(new int[] {1, 4, 4, 0}),
                        new List<int>(new int[] {1, 0, 5, 5}),
                        new List<int>(new int[] {1, 5, 0, 5}),
                        new List<int>(new int[] {1, 5, 5, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    }
                },
                new List<int>[9][] { // Orientation C
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[6] { // 2
                        new List<int>(new int[] {4, 0, 0}),
                        new List<int>(new int[] {0, 4, 0}),
                        new List<int>(new int[] {0, 0, 4}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 4
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4})
                    },
                    new List<int>[6] { // 6
                        new List<int>(new int[] {4, 1, 1}),
                        new List<int>(new int[] {1, 4, 1}),
                        new List<int>(new int[] {1, 1, 4}),
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 7
                        new List<int>(new int[] {1, 0, 4}),
                        new List<int>(new int[] {0, 4})
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    }
                },
            },
            new List<int>[4][][] { // T
                new List<int>[8][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 7
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[9][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 3
                        new List<int>(new int[] {5, 0, 0}),
                        new List<int>(new int[] {0, 5, 0}),
                        new List<int>(new int[] {0, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 4
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[6] { // 7
                        new List<int>(new int[] {5, 1, 1}),
                        new List<int>(new int[] {1, 5, 1}),
                        new List<int>(new int[] {1, 1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {5, 1, 0}),
                        new List<int>(new int[] {1, 5, 0}),
                        new List<int>(new int[] {1, 0, 5}),
                        new List<int>(new int[] {5, 0}),
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                },
                new List<int>[8][] { // Orientation D
                    new List<int>[8] { // 1
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 2
                        new List<int>(new int[] {0, 0, 4, 4}),
                        new List<int>(new int[] {0, 4, 0, 4}),
                        new List<int>(new int[] {4, 0, 0, 4}),
                        new List<int>(new int[] {0, 4, 4, 0}),
                        new List<int>(new int[] {4, 0, 4, 0}),
                        new List<int>(new int[] {4, 4, 0, 0}),
                        new List<int>(new int[] {0, 0, 5, 5}),
                        new List<int>(new int[] {0, 5, 0, 5}),
                        new List<int>(new int[] {5, 0, 0, 5}),
                        new List<int>(new int[] {0, 5, 5, 0}),
                        new List<int>(new int[] {5, 0, 5, 0}),
                        new List<int>(new int[] {5, 5, 0, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 3
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[2] { // 4
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 5
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 6
                        new List<int>(new int[] {1, 1, 4, 4}),
                        new List<int>(new int[] {1, 4, 1, 4}),
                        new List<int>(new int[] {4, 1, 1, 4}),
                        new List<int>(new int[] {1, 4, 4, 1}),
                        new List<int>(new int[] {4, 1, 4, 1}),
                        new List<int>(new int[] {4, 4, 1, 1}),
                        new List<int>(new int[] {1, 1, 5, 5}),
                        new List<int>(new int[] {1, 5, 1, 5}),
                        new List<int>(new int[] {5, 1, 1, 5}),
                        new List<int>(new int[] {1, 5, 5, 1}),
                        new List<int>(new int[] {5, 1, 5, 1}),
                        new List<int>(new int[] {5, 5, 1, 1}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[20] { // 7
                        new List<int>(new int[] {1, 0, 4, 4}),
                        new List<int>(new int[] {1, 4, 0, 4}),
                        new List<int>(new int[] {1, 4, 4, 0}),
                        new List<int>(new int[] {1, 0, 5, 5}),
                        new List<int>(new int[] {1, 5, 0, 5}),
                        new List<int>(new int[] {1, 5, 5, 0}),
                        new List<int>(new int[] {0, 4, 4}),
                        new List<int>(new int[] {4, 0, 4}),
                        new List<int>(new int[] {4, 4, 0}),
                        new List<int>(new int[] {0, 5, 5}),
                        new List<int>(new int[] {5, 0, 5}),
                        new List<int>(new int[] {5, 5, 0}),
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    },
                    new List<int>[8] { // 8
                        new List<int>(new int[] {1, 4, 4}),
                        new List<int>(new int[] {4, 1, 4}),
                        new List<int>(new int[] {4, 4, 1}),
                        new List<int>(new int[] {1, 5, 5}),
                        new List<int>(new int[] {5, 1, 5}),
                        new List<int>(new int[] {5, 5, 1}),
                        new List<int>(new int[] {4, 4}),
                        new List<int>(new int[] {5, 5})
                    }
                },
                new List<int>[9][] { // Orientation C
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[6] { // 2
                        new List<int>(new int[] {4, 0, 0}),
                        new List<int>(new int[] {0, 4, 0}),
                        new List<int>(new int[] {0, 0, 4}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 4
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4})
                    },
                    new List<int>[6] { // 6
                        new List<int>(new int[] {4, 1, 1}),
                        new List<int>(new int[] {1, 4, 1}),
                        new List<int>(new int[] {1, 1, 4}),
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[2] { // 7
                        new List<int>(new int[] {1, 0, 4}),
                        new List<int>(new int[] {0, 4})
                    },
                    new List<int>[2] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {4, 1}),
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {4})
                    }
                }
            },
            new List<int>[1][][] { // O
                new List<int>[9][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[4] { // 2
                        new List<int>(new int[] {0, 1}),
                        new List<int>(new int[] {0}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 4
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 5
                        new List<int>()
                    },
                    new List<int>[2] { // 6
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 7
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[4] { // 8
                        new List<int>(new int[] {1, 0}),
                        new List<int>(new int[] {1}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 9
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                }
            },
            new List<int>[2][][] { // I
                new List<int>[7][] { // Orientation A
                    new List<int>[2] { // 1
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 0}),
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[2] { // 3
                        new List<int>(new int[] {0}),
                        new List<int>()
                    },
                    new List<int>[1] { // 4
                        new List<int>()
                    },
                    new List<int>[2] { // 5
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[3] { // 6
                        new List<int>(new int[] {1, 1}),
                        new List<int>(new int[] {1}),
                        new List<int>()
                    },
                    new List<int>[2] { // 7
                        new List<int>(new int[] {1}),
                        new List<int>()
                    }
                },
                new List<int>[10][] { // Orientation B
                    new List<int>[3] { // 1
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 2
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 3
                        new List<int>(new int[] {0, 5}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[3] { // 4
                        new List<int>(new int[] {0, 4}),
                        new List<int>(new int[] {4, 0}),
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 5
                        new List<int>(new int[] {4})
                    },
                    new List<int>[1] { // 6
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 7
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 8
                        new List<int>(new int[] {1, 4}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 9
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {5})
                    },
                    new List<int>[3] { // 11
                        new List<int>(new int[] {5, 1}),
                        new List<int>(new int[] {1, 5}),
                        new List<int>(new int[] {5})
                    }
                }
            },
        };

        public static int Errors(int piece, List<int> keys, int pos, int rot) {
            int orient = rot; // L, J, T

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
                        pos--;
                    break;

                case 5: // O
                    if (rot > 2)
                        pos--;
                    break;

                case 6: // I
                    if (rot == 0)
                        pos--;
                    if (rot == 2)
                        pos += -2;
                    break;
            }

            foreach (List<int> movement in finesse[piece][orient][pos])
                if (keys.SequenceEqual(movement))
                    return 0;

            return Math.Max(0, keys.Count - finesse[piece][orient][pos][0].Count);
        }
    }
}
