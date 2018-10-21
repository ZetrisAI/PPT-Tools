using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPTTools {
    class GameHelper {
        public static int PieceDropped(VAMemory Game, int index) {
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

        public static int GarbageSent(VAMemory Game, int index) {
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

        public static int Keystroke(VAMemory Game, int index) => Game.ReadByte(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        0x140461B20
                    )) + 0x378
                )) + 0xB0
            )) + 0x3A + index * 0x02
        ));

        public static int CurrentPiece(VAMemory Game, int index) {
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

        public static int NextPiece(VAMemory Game, int index) {
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

        public static int PiecePosition(VAMemory Game, int index) {
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
                                        Game.ReadInt32(new IntPtr(
                                            0x140463FD8
                                        )) + 0x18
                                    )) + 0x380
                                )) + 0xB0
                            )) + 0x58
                        )) + 0x766
                    ));
            }

            return -1;
        }

        public static int PieceRotation(VAMemory Game, int index) {
            {
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
        }
        

        public static int BigFrames(VAMemory Game) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        0x140598A20
                    )) + 0x138
                )) + 0x30
            )) + 0x208
        ));

        public static int SmallFrames(VAMemory Game) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                0x1405989F0
            )) + 0x594
        ));

        public static int Rating(VAMemory Game) => Game.ReadInt16(new IntPtr(
            0x140599FF0
        ));

        public static int PlayerCount(VAMemory Game) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    0x140473760
                )) + 0x20
            )) + 0xB4
        ));

        public static int LocalSteam(VAMemory Game) => Game.ReadInt32(new IntPtr(
            0x1405A2010
        ));

        public static int PlayerSteam(VAMemory Game, int index) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    0x140473760
                )) + 0x20
            )) + 0x118 + index * 0x50
        ));
    }
}
