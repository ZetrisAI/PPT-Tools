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

            public static LogicHelper.FTX _FTX;
            public static LogicHelper.PPS _PPS;
            public static LogicHelper.APM _APM;
            public static LogicHelper.APC _APC;
            public static LogicHelper.KPP _KPP;
            public static LogicHelper.Finesse _Finesse;
            public static LogicHelper.Rating _Rating;
            public static LogicHelper.Duration _Duration;

            private static Timer Scan = new Timer();

            public static bool EnsureGame() {
                if (GameHelper.Game == null) {
                    if (Process.GetProcessesByName("puyopuyotetris").Length != 0) {
                        GameHelper.Game = new VAMemory("puyopuyotetris");

                        _FTX = new LogicHelper.FTX();
                        _PPS = new LogicHelper.PPS();
                        _APM = new LogicHelper.APM();
                        _APC = new LogicHelper.APC();
                        _KPP = new LogicHelper.KPP();
                        _Finesse = new LogicHelper.Finesse();
                        _Rating = new LogicHelper.Rating();
                        _Duration = new LogicHelper.Duration();

                    } else {
                        return false;
                    }
                
                } else if (Process.GetProcessesByName("puyopuyotetris").Length == 0) {
                    GameHelper.Game = null;
                    return false;
                }

                return true;
            }

            public static void Update(object sender, EventArgs e) {
                if (EnsureGame()) {
                    playerIndex = LogicHelper.FindPlayer();

                    if (GameHelper.BigFrames() < 148) {
                        // Don't Reset FTX, it regulates itself
                        _PPS.Reset();
                        _APM.Reset();
                        _APC.Reset();
                        _KPP.Reset();
                        _Finesse.Reset();
                        _Rating.Reset();
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
    }
}
