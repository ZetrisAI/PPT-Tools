using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPTTools {
    class GameHelper {
        public static int PieceDropped(VAMemory Game) => Game.ReadByte(new IntPtr(
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

        public static int GarbageSent(VAMemory Game) => Game.ReadInt32(new IntPtr(
            Game.ReadInt32(new IntPtr(
                Game.ReadInt32(new IntPtr(
                    Game.ReadInt32(new IntPtr(
                        Game.ReadInt32(new IntPtr(
                            Game.ReadInt32(new IntPtr(
                                0x140461B20
                            )) + 0x378
                        )) + 0x28
                    )) + 0xD0
                )) + 0x180
            )) + 0x70
        ));

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

        public static int Rating(VAMemory Game) => Game.ReadInt32(new IntPtr(
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
