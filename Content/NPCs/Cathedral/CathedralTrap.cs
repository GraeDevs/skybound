using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using skybound.Core;
using skybound.Content;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.NPCs.Cathedral
{
    internal class CathedralTrap : ModNPC
    {
        public Tile Parent;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }

        public override void SetDefaults()
        {
            NPC.width = 160;
            NPC.height = 10;
            NPC.immortal = true;
            NPC.dontTakeDamage = true;
            NPC.lifeMax = 1;
            NPC.dontCountMe = true;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.knockBackResist = 0;
            NPC.behindTiles = true;
        }

        public override void AI()
        {
            if (NPC.ai[0] < 10)
            {
                NPC.velocity.Y += 1.5f; NPC.damage = 120;
            }
            if (NPC.ai[0] > 40 && NPC.ai[0] < 50) { NPC.velocity.Y = -3; NPC.damage = 0; }
            if (NPC.ai[0]++ > 100) { NPC.ai[0] = 0; NPC.velocity.Y = 0.001f; NPC.ai[1] = 0; }

            if (NPC.velocity.Y == 0 && NPC.ai[1] != 1)
            {
                for (float k = 0; k <= 0.3f; k += 0.007f)
                {
                    Vector2 vel = new Vector2(1, 0).RotatedBy(-k) * Main.rand.NextFloat(8);
                    if (Main.rand.Next(2) == 0) vel = new Vector2(-1, 0).RotatedBy(k) * Main.rand.NextFloat(8); Dust.NewDustPerfect(NPC.Center + new Vector2(vel.X * 3, 5), DustID.Stone, vel * 0.7f);
                    Dust.NewDustPerfect(NPC.Center + new Vector2(vel.X * 3, 5), DustType<Dusts.Glow>(), vel);
                }
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item70.WithPitchVariance(0.6f), NPC.Center);

                foreach (Player Player in Main.player.Where(Player => Vector2.Distance(Player.Center, NPC.Center) <= 250))
                    Player.GetModPlayer<skyboundPlayer>().Shake = (250 - (int)Vector2.Distance(Player.Center, NPC.Center)) / 12;
                NPC.ai[1] = 1;
            }
        }

        public override bool? CanHitNPC(NPC target) => true;

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D tex2 = Request<Texture2D>("skybound/Content/Tiles/Cathedral/CathedralTrapDraw").Value;

            int count = NPC.ai[0] < 10 ? (int)NPC.ai[0] / 3 : NPC.ai[0] > 40 ? (60 - (int)NPC.ai[0]) / 4 : 3;
            for (int k = 1; k <= count; k++)
                spriteBatch.Draw(tex2, NPC.position - screenPos + new Vector2(8, -48 - k * 28), drawColor);
        }
    }
}