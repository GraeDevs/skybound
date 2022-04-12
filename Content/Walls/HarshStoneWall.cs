using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.Walls
{
    public class HarshStoneWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(7, 28, 28));
            ItemDrop = ModContent.ItemType<Content.Items.Placeable.Walls.HarshStoneWallItem>();
        }

    }
}