using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using skybound.Core;
using skybound.Content.Dusts;

namespace skybound.Content.Tiles.Cathedral
{
    internal class CathedralOrb : ModTile
    {
        int maxpick = 500000;
        public string baseDirectory => (GetType().Namespace).Replace(".", "/");
        public override void SetStaticDefaults()
        {
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.FramesOnKillWall[Type] = true;
            MinPick = 5;
            ItemDrop = ItemType<Items.Placeable.Tiles.CathedralOrb>();
            DustType = ModContent.DustType<CathedralDust>();
            AddMapEntry(new Color(143, 96, 204));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 143 * 0.005f;
            g = 96 * 0.005f;
            b = 204 * 0.005f;
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.rand.Next(50) == 0)
            {
                Vector2 pos = new Vector2(i + 0.5f, j + 0.5f) * 16;
                skyboundUtils.Bolt(pos, pos + Vector2.One.RotatedByRandom(6.28f) * Main.rand.Next(10, 20), ModContent.DustType<Dusts.TempusBolt>(), 0.4f, 9);
            }
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Texture2D tex = Request<Texture2D>("skybound/Content/Assets/GlowOrb").Value;
            Texture2D tex2 = Request<Texture2D>("skybound/Content/Assets/GlowBeams").Value;


            spriteBatch.End();
            spriteBatch.Begin(default, BlendState.Additive, SamplerState.PointClamp, default, default);

            Vector2 pos = (new Vector2(i, j) + skyboundUtils.TileAdj) * 16 + Vector2.One * 8 - Main.screenPosition;
            for (int k = 0; k < 3; k++)
                spriteBatch.Draw(tex, pos, tex.Frame(), new Color(143, 96, 204) * (0.65f + (float)Math.Sin(skyboundWorld.rottime) * 0.05f), 0, tex.Size() / 2, k * 0.3f, 0, 0);
            spriteBatch.Draw(tex2, pos, tex.Frame(), new Color(143, 96, 204) * (0.65f + (float)Math.Sin(skyboundWorld.rottime) * 0.10f), (float)Math.Sin(skyboundWorld.rottime) * 0.1f, tex.Size() / 2, 0.6f, 0, 0);
            spriteBatch.Draw(tex2, pos, tex.Frame(), new Color(143, 96, 204) * (0.65f - (float)Math.Sin(skyboundWorld.rottime) * 0.10f), 2 + -(float)Math.Sin(skyboundWorld.rottime + 1) * 0.1f, tex.Size() / 2, 0.9f, 0, 0);

            spriteBatch.End();
            spriteBatch.Begin(default, default, SamplerState.PointClamp, default, default);
        }
    }
}