using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.Walls
{
    public class CathedralBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(0, 0, 0));
            DustType = DustType<Dusts.CathedralDust>();
            ItemDrop = ModContent.ItemType<Content.Items.Placeable.Walls.CathedralBrickWallItem>();
        }

    }
}