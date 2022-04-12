using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using skybound.Core;
using skybound.Content.Tiles.Cathedral;

namespace skybound.Content.Items.Placeable.Tiles
{
    public class CathedralAccent: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cathedral Accent Brick");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Green;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<CathedralAccentTile>();
        }
    }
}