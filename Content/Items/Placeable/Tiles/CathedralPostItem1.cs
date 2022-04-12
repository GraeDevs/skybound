﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using skybound.Core;
using skybound.Content.Tiles.Cathedral;

namespace skybound.Content.Items.Placeable.Tiles
{
    public class CathedralPostItem1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cathedral Post 1");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.rare = 2;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CathedralPost1>();
        }
    }
}