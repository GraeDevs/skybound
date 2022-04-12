using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;


namespace skybound.Content.Dusts
{
    public class Pulse : ModDust
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

    public class Pulse2 : Pulse
    {
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += 0.05f;
            dust.color = Color.Lavender;

            dust.scale *= 0.92f;
            if (dust.scale < 0.6f)
            {
                dust.active = false;
            }
            return false;
        }
    }

    public class Pulse3 : Pulse
    {
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.fadeIn++;
            

            dust.scale *= 0.999f;
            dust.alpha = 155 + (int)(dust.fadeIn > 300 ? (dust.fadeIn - 300) / 300 * 100 : (300 - dust.fadeIn) / 300 * 100);

            if (dust.fadeIn > 300) dust.active = false;

            return false;
        }
    }
}
