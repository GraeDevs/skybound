using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using skybound.Core;
using skybound.Content.Tiles;

namespace skybound.Content.Items.Placeable.Tiles
{
    public class TestTileItem : ModItem
    {
        public override string Texture => "skybound/Placeholder";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Test Tile");
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
            Item.consumable = true;
            Item.createTile = ModContent.TileType<TestTile>();
        }
    }
}
