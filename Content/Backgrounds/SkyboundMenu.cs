﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using skybound.Core;

namespace skybound.Content.Backgrounds
{
    public class SkyboundMenu : ModSurfaceBackgroundStyle
    {
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }
        public override int ChooseFarTexture()
        {
            return -1;
        }

        public override int ChooseMiddleTexture()
        {
            return -1;
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return BackgroundTextureLoader.GetBackgroundSlot("skybound/Content/Backgrounds/SkyboundMenuClose");
        }
        public override bool PreDrawCloseBackground(SpriteBatch spriteBatch)
        {
            float a = 2800f;
            float b = 1750f;
            int[] textureSlots = new int[] {
                BackgroundTextureLoader.GetBackgroundSlot("skybound/Content/Backgrounds/SkyboundMenuFar"),
                BackgroundTextureLoader.GetBackgroundSlot("skybound/Content/Backgrounds/SkyboundMenuMid"),
                BackgroundTextureLoader.GetBackgroundSlot("skybound/Content/Backgrounds/SkyboundMenuClose"),
            };
            int length = textureSlots.Length;
            for (int i = 0; i < textureSlots.Length; i++)
            {
                float bgParallax = 0.37f + 0.2f - (0.1f * (length - i));
                int textureSlot = textureSlots[i];
                Main.instance.LoadBackground(textureSlot);
                float bgScale = 1.9f;
                int bgW = (int)(Main.backgroundWidth[textureSlot] * bgScale);
                SkyManager.Instance.DrawToDepth(spriteBatch, 1f / bgParallax);
                float screenOff = typeof(Main).GetFieldValue<float>("screenOff", Main.instance);
                float scAdj = typeof(Main).GetFieldValue<float>("scAdj", Main.instance);
                int bgStart = (int)(-Math.IEEERemainder(Main.screenPosition.X * bgParallax, bgW) - (bgW / 2));
                int bgTop = (int)((-Main.screenPosition.Y + screenOff / 2f) / (Main.worldSurface * 16.0) * a + b) + (int)scAdj - (length * 150);
                if (Main.gameMenu)
                {
                    bgTop = 320;
                }
                Color backColor = typeof(Main).GetFieldValue<Color>("ColorOfSurfaceBackgroundsModified", Main.instance);
                int bgLoops = Main.screenWidth / bgW + 2;
                if (Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int k = 0; k < bgLoops; k++)
                    {
                        spriteBatch.Draw(TextureAssets.Background[textureSlot].Value,
                            new Vector2(bgStart + bgW * k, MathHelper.Clamp(bgTop, -1300, 0)),
                            new Rectangle(0, 0, Main.backgroundWidth[textureSlot], Main.backgroundHeight[textureSlot]),
                            backColor, 0f, default, bgScale, SpriteEffects.None, 0f);
                    }
                }
            }
            return false;
        }
    }
}
