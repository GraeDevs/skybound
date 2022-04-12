using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace skybound.Content.Items.Useable.Cathedral
{
    public class PostKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tempus Puzzle Key");
            Tooltip.SetDefault("Strange energy radiates this key.");
        }

        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.GoldenKey);
            Item.width = 26;
            Item.height = 52;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Orange;
        }
    }
}
