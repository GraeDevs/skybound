using Terraria.ID;
using Terraria.ModLoader;
using skybound.Content.Tiles.Cathedral;

namespace skybound.Content.Items.Placeable.Tiles
{
    public class CathedralPortalItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("DEV ONLY, CHEAT ITEM");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 20;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 2000;
			Item.createTile = ModContent.TileType<CathedralPortalTile>();
		}

	}
}