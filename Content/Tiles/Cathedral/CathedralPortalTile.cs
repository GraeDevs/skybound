using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using skybound.Content.NPCs.Cathedral;
using skybound.Core;

namespace skybound.Content.Tiles.Cathedral
{
    public class CathedralPortalTile : ModTile
    {
        public int maxPick = 5000000;
        public bool Active = false;
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            TileObjectData.newTile.Width = 9;
            TileObjectData.newTile.Height = 7;
            TileObjectData.newTile.Origin = new Point16(5, 6);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cathedral Portal");
            AddMapEntry(new Color(56, 56, 56), name);
            MinPick = maxPick;
            DustType = ModContent.DustType<Dusts.CathedralDust>();
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 143 * 0.003f;
            g = 96 * 0.003f;
            b = 204 * 0.003f;
        }

        public override bool RightClick(int i, int j)
        {
            if (Active == false)
            {
                if (Flags.bastionPuzzleComplete == false)
                {
                    Tile tile = Framing.GetTileSafely(i, j);
                    Point topLeft = new Point((i - tile.TileFrameX / 18) * 16, (j - tile.TileFrameY / 18) * 16);
                    int offsetCenter = (int)(16 * 4.4f);

                    NPC.NewNPC(new EntitySource_SpawnNPC(), topLeft.X + offsetCenter, topLeft.Y + offsetCenter, ModContent.NPCType<FuturePortal>(), 1);
                }
            }
            else
            {
                Main.NewText("Fuck you");
            }
            return true;
        }
    }
}