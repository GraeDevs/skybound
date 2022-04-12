using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using skybound.Core;

namespace skybound.Content.Tiles.Cathedral
{
    public class CathedralPost1 : ModTile
    {
        public int maxPick = 5000000;
        public bool rightClicked = false;
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileLighted[Type] = true;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.Origin = new Point16(0, 2);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cathedral Post");
            AddMapEntry(new Color(56, 56, 56), name);
            MinPick = maxPick;
            DustType = ModContent.DustType<Dusts.CathedralDust>();
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (rightClicked == false)
            {
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = ModContent.ItemType<Items.Useable.Cathedral.PostKey>();
            }
            else
            {
                player.cursorItemIconEnabled = false;
            }
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if (rightClicked)
            {
                r = 143 * 0.003f;
                g = 96 * 0.003f;
                b = 204 * 0.003f;
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (rightClicked)
            {
                if (Main.rand.Next(200) == 0)
                {
                    Vector2 pos = new Vector2(i + 0.5f, j + 0.5f) * 16;
                    skyboundUtils.Bolt(pos, pos + Vector2.One.RotatedByRandom(6.28f) * Main.rand.Next(15, 35), ModContent.DustType<Dusts.TempusBolt>(), 0.4f, 9);
                }
            }
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            if (player.HasItem(ModContent.ItemType<Items.Useable.Cathedral.PostKey>()))
            {
                if (rightClicked == false)
                {
                    rightClicked = true;
                    Flags.puzzlePosts += 1;
                    //Main.PlaySound(ModContent.GetInstance<skybound>().GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/Custom/Hit").WithVolume(.5f).WithPitchVariance(.5f));
                    for (int t = 0; t < 40; t++)
                    {
                        int num = Dust.NewDust(Main.LocalPlayer.position, Main.LocalPlayer.width, Main.LocalPlayer.height, ModContent.DustType<Dusts.Pulse3>());
                        Main.dust[num].noGravity = true;
                        Dust expr_62_cp_0 = Main.dust[num];
                        expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                        Dust expr_92_cp_0 = Main.dust[num];
                        expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                        if (Main.dust[num].position != Main.LocalPlayer.Center)
                        {
                            Main.dust[num].velocity = Main.LocalPlayer.DirectionTo(Main.dust[num].position) * 6f;
                        }
                    }
                }
            }
            return false;
        }
    }
}