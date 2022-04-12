using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Chat;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.WorldBuilding;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Generation;
using ReLogic.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using skybound.Content.Structures;

namespace skybound.Core
{
    public class WorldGeneration : ModSystem
    {
        public static Vector2 CathedralVector = new Vector2(-1, -1);

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            int ShiniesIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            int GuideIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Sunflowers"));
            if (GuideIndex == -1)
                return;
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex2, new PassLegacy("Cathedral", delegate (GenerationProgress progress, GameConfiguration configuration)
                {
                    progress.Message = "Unlocking the Knowledge Vault";
                    Point origin = new((int)(Main.maxTilesX * 0.55f), (int)(Main.maxTilesY * 0.65f));
                    WorldUtils.Gen(origin, new Shapes.Rectangle(289, 217), Actions.Chain(new GenAction[]
                    {
                        new Actions.SetLiquid(0, 0)
                    }));
                    CathedralVector = origin.ToVector2();

                    CathedralGen biome = new();
                    CathedralClear delete = new();
                    delete.Place(origin, WorldGen.structures);
                    biome.Place(origin, WorldGen.structures);

                }));
            }
        }
    }
}
