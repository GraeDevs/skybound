using Terraria.ModLoader;
using Terraria.ID;
using skybound.Content.Walls;

namespace skybound.Content.Items.Placeable.Walls
{
    public class CathedralBrickWallItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cathedral Brick Wall");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<CathedralBrickWall>();
        }
    }
}