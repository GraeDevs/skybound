using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

using skybound.Core;
using skybound.Base;
using skybound.Content.Tiles.Cathedral;
using skybound.Content.Walls;

namespace skybound.Content.Structures
{
    public class CathedralClear : MicroBiome
    {
        public override bool Place(Point origin, StructureMap structures)
        {
            Mod mod = skybound.Instance;
            Dictionary<Color, int> colorToTile = new()
            {
                [new Color(150, 150, 150)] = -2,
                [Color.Black] = -1
            };
            Texture2D texClear = ModContent.Request<Texture2D>("skybound/Content/Structures/CathedralClear", AssetRequestMode.ImmediateLoad).Value;

            bool genned = false;
            bool placed = false;
            while (!genned)
            {
                if (placed)
                    continue;

                Main.QueueMainThreadAction(() =>
                {
                    TexGen genA = BaseWorldGenTex.GetTexGenerator(texClear, colorToTile);
                    genA.Generate(origin.X, origin.Y, true, true);


                    genned = true;
                });

                placed = true;
            }

            return true;
        }
    }

    public class CathedralGen : MicroBiome
    {
        public override bool Place(Point origin, StructureMap structures)
        {
            Mod mod = skybound.Instance;
            Dictionary<Color, int> colorToTile = new()
            {
                [new Color(0, 0, 255)] = ModContent.TileType<CathedralBrickTile>(),
                [new Color(255, 0, 0)] = ModContent.TileType<CathedralAccentTile>(),
                [new Color(0, 255, 0)] = ModContent.TileType<CathedralTrapTile>(),
                [new Color(150, 150, 150)] = -2,
                [Color.Black] = -1
            };

            Dictionary<Color, int> colorToWall = new()
            {
                [new Color(0, 0, 255)] = ModContent.WallType<CathedralBrickWall>(),
                [new Color(150, 150, 150)] = -2,
                [Color.Black] = -1
            };
            Texture2D tex = ModContent.Request<Texture2D>("skybound/Content/Structures/Cathedral", AssetRequestMode.ImmediateLoad).Value;
            Texture2D texWalls = ModContent.Request<Texture2D>("skybound/Content/Structures/CathedralWalls", AssetRequestMode.ImmediateLoad).Value;
            Texture2D texClear = ModContent.Request<Texture2D>("skybound/Content/Structures/CathedralClear", AssetRequestMode.ImmediateLoad).Value;

            bool genned = false;
            bool placed = false;
            while (!genned)
            {
                if (placed)
                    continue;

                Main.QueueMainThreadAction(() =>
                {
                    TexGen genA = BaseWorldGenTex.GetTexGenerator(texClear, colorToTile);
                    genA.Generate(origin.X, origin.Y, true, true);


                    TexGen gen = BaseWorldGenTex.GetTexGenerator(tex, colorToTile, texWalls, colorToWall);
                    gen.Generate(origin.X, origin.Y, true, true);

                    

                    genned = true;
                });

                placed = true;
            }

            return true;
        }
    }
}
