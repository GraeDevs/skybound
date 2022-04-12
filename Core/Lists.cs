using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace skybound.Core
{
    public static class TileLists
    {
        #region Tile Lists

        public static List<int> CorruptTiles = new()
        {
            23,
            25,
            112,
            163,
            398,
            400
        };

        public static List<int> CrimsonTiles = new()
        {
            199,
            203,
            234,
            200,
            399,
            401,
            205
        };

        public static List<int> EvilTiles = new()
        {
            23,
            25,
            112,
            163,
            398,
            400,
            199,
            203,
            234,
            200,
            399,
            401,
            205
        };

        public static List<int> HallowTiles = new()
        {
            109,
            117,
            116,
            164,
            402,
            403,
            115
        };

        public static List<int> ForestTiles = new()
        {
            2
        };

        public static List<int> GloomTiles = new()
        {
            59,
            70,
            194,
        };

        public static List<int> GlowingMushTiles = new()
        {
            59,
            70,
            190
        };

        public static List<int> CloudTiles = new()
        {
            189,
            196,
            460
        };

        public static List<int> HellTiles = new()
        {
            57,
            198,
            58,
            76,
            75
        };

        public static List<int> SnowTiles = new()
        {
            161,
            206,
            164,
            200,
            163,
            162,
            147,
            148
        };

        public static List<int> DesertTiles = new()
        {
            53,
            396,
            397,
            403,
            402,
            401,
            399,
            400,
            398
        };

        public static List<int> JungleTiles = new()
        {
            59,
            120,
            60,
        };

        public static List<int> DirtTiles = new()
        {
            TileID.Dirt,
            59,
            40
        };

        public static List<int> OreTiles = new()
        {
            408,
            7,
            166,
            6,
            167,
            9,
            168,
            8,
            169,
            22,
            204,
            37,
            58,
            107,
            221,
            108,
            222,
            111,
            223,
            211,
            //ModContent.TileType<DragonLeadOreTile>(),
            //ModContent.TileType<KaniteOreTile>(),
            //ModContent.TileType<SapphironOreTile>(),
            //ModContent.TileType<ScarlionOreTile>(),
            //ModContent.TileType<StarliteOreTile>(),
            //ModContent.TileType<XenomiteOreBlock>()
        };

        public static List<int> HotTiles = new()
        {
            53,
            396,
            397,
            403,
            402,
            401,
            399,
            400,
            398,
            57,
            198,
            58,
            76,
            75
        };

        public static List<int> NatureTiles = new()
        {
            2,
            59,
            120,
            60
        };

        public static List<int> BlacklistTiles = new()
        {
            TileID.BlueDungeonBrick,
            TileID.GreenDungeonBrick,
            TileID.PinkDungeonBrick,
            TileID.LihzahrdBrick,
            TileID.BeeHive,
            TileID.Granite,
            TileID.Marble,
        };

        public static List<int> ModdedChests = new();

        public static List<int> ModdedDoors = new()
        {
           
        };
        #endregion
    }
}
