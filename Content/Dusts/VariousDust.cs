using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


namespace skybound.Content.Dusts
{
    public class VariousDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.03f;
            dust.noGravity = true;
            dust.noLight = false;
            dust.scale *= 3f;
            dust.color.R = 227;
            dust.color.G = 240;
            dust.color.B = 255;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return dust.color * ((255 - dust.alpha) / 255f);
        }

        public override bool Update(Dust dust)
        {
            dust.rotation += 0.05f;

            dust.scale *= 0.97f;
            if (dust.scale < 0.2f)
            {
                dust.active = false;
            }
            return false;
        }
    }
    public class GlowDust : VariousDust
    {
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += 0.05f;
            dust.alpha = 175;
            dust.color = Color.White;

            dust.scale *= 0.92f;
            if (dust.scale < 0.8f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
