using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace skybound.Content.Tiles.Cathedral
{
    public class CathedralPillarTileLarge : ModTile
    {
        public int maxPick = 5000000;
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.Width = 5;
            TileObjectData.newTile.Height = 18;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Origin = new Point16(-4, 2);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cathedral Pillar");
            AddMapEntry(new Color(56, 56, 56), name);
            MinPick = maxPick;
            DustType = ModContent.DustType<Dusts.CathedralDust>();
        }

    }
}