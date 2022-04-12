using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using Terraria.Localization;
using System;
using Terraria.Audio;
using skybound.Content.Dusts;
using skybound.Core;
using Terraria.GameContent;
using skybound;

namespace skybound.Content.NPCs.Cathedral
{
    public class FuturePortal : ModNPC
    {
        public override string Texture => "skybound/Content/Assets/PortalTexture";
        public int counter = 01;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Portal");
        }

        public override void SetDefaults()
        {
            NPC.friendly = true;
            NPC.width = 50;
            NPC.height = 10;
            NPC.dontTakeDamage = true;
            NPC.noGravity = true;
            NPC.aiStyle = -1;
            NPC.lifeMax = 999;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.knockBackResist = 0;
            NPC.noTileCollide = true;
            NPC.alpha = 20;
            NPC.npcSlots = 0;
            NPC.hide = true;
            NPC.behindTiles = true;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void DrawBehind(int index)
        {
            Main.instance.DrawCacheNPCsBehindNonSolidTiles.Add(index);
        }

        public override bool UsesPartyHat() => false;
        private float RotTime;
        public override void AI()
        {
            Lighting.AddLight(NPC.Center, new Color(143, 96, 204).ToVector3());
            NPC.dontTakeDamage = true;
            NPC.rotation += .02f;

            if (Vector2.Distance(Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2), NPC.Center) <= Main.screenWidth / 2 + 100)
            {
                RotTime += (float)Math.PI / 120;
                RotTime *= 1.01f;
                if (RotTime >= Math.PI) RotTime = 0;
                float timer = RotTime;

            }
        }
        public override bool CanChat() => true;
        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Yes. I'm a telepathic portal. Now go, before I close myself.";
                case 1:
                    return "You may proceed, at your own wish.";
                case 2:
                    return "Wow, 'morty', didn't think I had any charge left.";
                default:
                    return "Do you wish to proceed to the future, Terrarian?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Proceed to Future";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                Main.NewText("Estimated wait time: 500000 years.");
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = TextureAssets.Npc[NPC.type].Value;
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.TransformationMatrix);

            spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, NPC.frame, NPC.GetAlpha(Color.Gray), NPC.rotation, NPC.frame.Size() / 2, NPC.scale * 0.5f, SpriteEffects.None, 0f);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.GameViewMatrix.TransformationMatrix);
            return false;
        }
    }
}
