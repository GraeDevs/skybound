using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using SubworldLibrary;
using System.Linq;
using skybound.Content.Tiles;
using Terraria.UI;
using Terraria.WorldBuilding;
using Terraria.IO;
using System;
using ReLogic.Content;
using skybound.Core;
using skybound.Base;

using skybound.Content.Tiles.Barra;

namespace skybound.Content.Subworlds.Barra
{
    public class Barra : Subworld
    {
        public override int Width => 3000;
        public override int Height => 1200;
        public override bool NormalUpdates => true;
        public override bool ShouldSave => true;
        public override bool NoPlayerSaving => false;
        public static double rockLayerHigh = 0.0;
        public static double rockLayerLow = 0.0;
        public static double surfaceLayer = 200;

        public override string Name => "Barra: The Junkyard Planet";

        public override List<GenPass> Tasks => new List<GenPass>()
        {
           new BarraGen(progress =>
           {

           })
        };

        public override void Load()
        {
            Main.cloudAlpha = 0;
            Main.numClouds = 0;
            Main.rainTime = 0;
            Main.raining = false;
            Main.maxRaining = 0f;
            Main.slimeRain = false;

            Main.dayTime = true;
            Main.time = 40000;
        }

        public class BarraGen : GenPass
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Loading";
                WorldGen.noTileActions = true;
                Main.spawnTileY = 827;
                Main.spawnTileX = 432;
                Main.worldSurface = 635;
                Main.rockLayer = 635;

                Mod mod = skybound.Instance;
                Dictionary<Color, int> colorToTile = new()
                {
                    [new Color(151, 83, 61)] = ModContent.TileType<DustTile>(),
                    [new Color(102, 59, 66)] = ModContent.TileType<HarshRockTile>(),
                    [new Color(150, 150, 150)] = -2,
                    [Color.Black] = -1
                };

                Texture2D tex = ModContent.Request<Texture2D>("skybound/Content/Planets/Barra/BarraTex2", AssetRequestMode.ImmediateLoad).Value;
                Texture2D liquidTex = ModContent.Request<Texture2D>("skybound/Content/Planets/Barra/BarraTexOil", AssetRequestMode.ImmediateLoad).Value;
                bool genned = false;
                bool placed = false;
                while (!genned)
                {
                    if (placed)
                        continue;

                    Main.QueueMainThreadAction(() =>
                    {
                        TexGen gen = BaseWorldGenTex.GetTexGenerator(tex, colorToTile, liquidTex);
                        gen.Generate(0, 0, true, true);

                        genned = true;
                    });

                    placed = true;
                }
            }
            private Action<GenerationProgress> method;

            public BarraGen(Action<GenerationProgress> method) : base("", 1)
            {
                this.method = method;
            }

            public BarraGen(float weight, Action<GenerationProgress> method) : base("", weight)
            {
                this.method = method;
            }

        }

        public class BarraBiome : ModBiome
        {
            public override ModWaterStyle WaterStyle => ModContent.GetInstance<Waters.Oil>();
            public override void SetStaticDefaults()
            {
                DisplayName.SetDefault("Barra: The Junkyard Planet");
            }

            public override bool IsBiomeActive(Player player)
            {
                return ModContent.GetInstance<TileCount>().barraCount >= 15;
            }
        }
    }
}
