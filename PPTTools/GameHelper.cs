using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PPTTools {
    class GameHelper {
        public static VAMemory Game;

        public static class GameState {
            public static int playerIndex = 0;

            public static Modules.FTX _FTX;
            public static Modules.PPS _PPS;
            public static Modules.APM _APM;
            public static Modules.APC _APC;
            public static Modules.KPP _KPP;
            public static Modules.Finesse _Finesse;
            public static Modules.Rating _Rating;
            public static Modules.Duration _Duration;

            private static Timer Scan = new Timer();

            public static bool EnsureGame() {
                if (Game == null) {
                    if (Process.GetProcessesByName("puyopuyotetris").Length != 0) {
                        Game = new VAMemory("puyopuyotetris");

                        _FTX = new Modules.FTX();
                        _PPS = new Modules.PPS();
                        _APM = new Modules.APM();
                        _APC = new Modules.APC();
                        _KPP = new Modules.KPP();
                        _Finesse = new Modules.Finesse();
                        _Rating = new Modules.Rating();
                        _Duration = new Modules.Duration();

                    } else {
                        return false;
                    }
                
                } else if (Process.GetProcessesByName("puyopuyotetris").Length == 0) {
                    Game = null;
                    return false;
                }

                return true;
            }

            public static void Update(object sender, EventArgs e) {
                if (EnsureGame()) {
                    playerIndex = FindPlayer();

                    if (BigFrames() < 148) {
                        // Don't Reset FTX, it regulates itself
                        _PPS.Reset();
                        _APM.Reset();
                        _APC.Reset();
                        _KPP.Reset();
                        _Finesse.Reset();
                        // Don't Reset Rating, it regulates itself
                        _Duration.Reset();
                    } else {
                        _FTX.Update();
                        _PPS.Update();
                        _APM.Update();
                        _APC.Update();
                        _KPP.Update();
                        _Finesse.Update();
                        _Rating.Update();
                        _Duration.Update();
                    }
                }
            }

            public static void Reset() {
                if (EnsureGame()) {
                    _FTX.Reset();
                    _PPS.Reset();
                    _APM.Reset();
                    _APC.Reset();
                    _KPP.Reset();
                    _Finesse.Reset();
                    _Rating.Reset();
                    _Duration.Reset();
                }
            }

            static GameState() {
                EnsureGame();

                Update(null, EventArgs.Empty);

                Scan.Interval = 3;
                Scan.Enabled = true;
                Scan.Tick += Update;
            }
        }

        public static int Score(int index) => Game.ReadByte(new IntPtr(
            Game.ReadInt32(new IntPtr(
                0x14057F048
            )) + 0x38 + index * 0x04
        ));

        public static int PieceDropped(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x140460C08
                                        )) + 0x18
                                    )) + 0x268
                                )) + 0x38
                            )) + 0x3C8
                        )) + 0x1C
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x1405989D0
                                        )) + 0x78
                                    )) + 0x20
                                )) + 0xA8
                            )) + 0x3C8
                        )) + 0x1C
                    ));
            }

            return -1;
        }

        public static int GarbageSent(int index) {
            switch (index) {
                case 0:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140461B20
                                    )) + 0x378
                                )) + 0x28
                            )) + 0xD0
                        )) + 0x3C
                    ));

                case 1:
                    return Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x140461B20
                                        )) + 0x378
                                    )) + 0x28
                                )) + 0x18
                            )) + 0xD0
                        )) + 0x64
                    ));
            }

            return -1;
        }

        public static int Keystroke(int index) => Game.ReadByte(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        0x140461B20
                    )) + 0x378
                )) + 0xB0
            )) + 0x3A + index * 0x02
        ));

        public static int CurrentPiece(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140461B20
                                    )) + 0x378
                                )) + 0xC0
                            )) + 0x120
                        )) + 0x110
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140461B20
                                    )) + 0x378
                                )) + 0x20
                            )) + 0x40
                        )) + 0x400
                    ));
            }

            return -1;
        }

        public static int NextPiece(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140461B20
                                )) + 0x378
                            )) + 0xB8
                        )) + 0x15C
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x1405989D0
                                    )) + 0x78
                                )) + 0x28
                            )) + 0xB8
                        )) + 0x15C
                    ));
            }

            return -1;
        }

        public static int PiecePosition(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140461B20
                                )) + 0x378
                            )) + 0x40
                        )) + 0x100
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        0x140461B20
                                    )) + 0x380
                                )) + 0xC0
                            )) + 0x120
                        )) + 0x1E
                    ));
            }

            return -1;
        }

        public static int PieceRotation(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x140460C08
                                        )) + 0x18
                                    )) + 0x268
                                )) + 0x38
                            )) + 0x3C8
                        )) + 0x18
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x1405989D0
                                        )) + 0x78
                                    )) + 0x20
                                )) + 0xA8
                            )) + 0x3C8
                        )) + 0x18
                    ));
            }

            return -1;
        }

        public static int LinesCleared(int index) {
            switch (index) {
                case 0:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    0x140461B20
                                )) + 0x378
                            )) + 0xA8
                        )) + 0x2F8
                    ));

                case 1:
                    return Game.ReadByte(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                Game.ReadInt32(new IntPtr(
                                    Game.ReadInt32(new IntPtr(
                                        Game.ReadInt32(new IntPtr(
                                            0x140461B20
                                        )) + 0x378
                                    )) + 0xA8
                                )) + 0x270
                            )) + 0x20
                        )) + 0x2F8
                    ));
            }

            return -1;
        }

        public static int BigFrames() => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        0x140598A20
                    )) + 0x138
                )) + 0x30
            )) + 0x208
        ));

        public static int SmallFrames() => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                0x1405989F0
            )) + 0x594
        ));

        public static int Rating() => Game.ReadInt16(new IntPtr(
            0x140599FF0
        ));

        public static int PlayerCount() => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    0x140473760
                )) + 0x20
            )) + 0xB4
        ));

        public static int LocalSteam() => Game.ReadInt32(new IntPtr(
            0x1405A2010
        ));

        public static int PlayerSteam(int index) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    0x140473760
                )) + 0x20
            )) + 0x118 + index * 0x50
        ));

        public static int FindPlayer() {
            if (PlayerCount() < 2)
                return 0;

            int localSteam = LocalSteam();

            for (int i = 0; i < 2; i++)
                if (localSteam == PlayerSteam(i))
                    return i;

            return 0;
        }

        private enum MatchState {
            Menu,
            Match,
            Finished
        }
        private static MatchState matchState = MatchState.Menu;

        public static bool EnsureMatch() {
            if (Game.ReadInt32(new IntPtr(0x140573A78)) != 0x0) {
                if (matchState == MatchState.Match) {
                    matchState = MatchState.Finished;
                }
            }

            int scoreAddress = Game.ReadInt32(new IntPtr(0x14057F048));

            if (scoreAddress == 0x0) {
                if (matchState == MatchState.Finished)
                    matchState = MatchState.Menu;

            } else if (matchState == MatchState.Menu)
                matchState = MatchState.Match;

            return matchState == MatchState.Match;
        }
    }
}
