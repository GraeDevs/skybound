using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using skybound.Content.Dusts;
using skybound.Core;
using skybound.Content.Items.Placeable.Tiles;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.Tiles.Cathedral
{
    public class CathedralBrickTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<CathedralDust>();
            SoundType = 21;
            SoundStyle = 2;
            MineResist = 1f;
            MinPick = 50;
            AddMapEntry(new Color(18, 18, 18));
            ItemDrop = ModContent.ItemType<CathedralBrick>();
        }
    }
}