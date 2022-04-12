using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ModLoader;
using skybound.Core;

namespace skybound.Content.Biomes
{
    public class BastionBiome : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<TileCount>().bastionTileCount >= 1;
            bool b2 = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;


            return b1 && b2;
        }
    }
}
