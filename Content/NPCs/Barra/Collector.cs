using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
namespace skybound.Content.NPCs.Barra
{
    public class Collector : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Collector");
            Main.npcFrameCount[NPC.type] = 7;
        }

        public override void SetDefaults()
        {
            NPC.height = 50;
            NPC.width = 52;
            NPC.lifeMax = 110;
            NPC.damage = 40;
            NPC.aiStyle = -1;
            NPC.immortal = true;
            NPC.spriteDirection = -NPC.direction;
        }

        public override void AI()
        {
            /*AI fields:
             * 0: state
             * 1: timer
             */
            Player target = Main.player[NPC.target];
            switch (NPC.ai[0])
            {
                case 0://waiting
                    //npc.immortal = true;
                    if (Main.player.Any(n => Vector2.Distance(n.Center, NPC.Center) <= 100))
                    {
                        NPC.ai[0] = 1;
                        NPC.immortal = false;
                    }
                    break;

                case 1://popping up from ground
                    if (NPC.ai[1]++ >= 50) NPC.ai[0] = 2;
                    NPC.TargetClosest();
                    break;
                case 2:
                    if(NPC.velocity.Y == 0)
                    {
                        NPC.velocity.Y = 0;
                    }
                    break;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            switch (NPC.ai[0])
            {
                case 0:
                    NPC.frame.Y = 0;
                    break;

                case 1:
                    NPC.frame.Y = frameHeight + frameHeight * (int)(NPC.ai[1] / 5);

                    break;
                case 2:
                    NPC.frame.Y = 6;
                    break;
            }
        }
    }
}
