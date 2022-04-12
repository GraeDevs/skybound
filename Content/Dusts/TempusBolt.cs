using Microsoft.Xna.Framework;
using skybound.Core;
using Terraria;
using Terraria.ModLoader;

namespace skybound.Content.Dusts
{
    public class Electric : ModDust
    {
        //Put this into any method requiring dust, and if you want it drawn as lightning
        /* Vector2 pos = new Vector2(i + 0.5f, j + 0.5f) * 16;
                DrawHelper.DrawElectricity(pos, pos + Vector2.One.RotatedByRandom(6.28f) * Main.rand.Next(15, 35), DustType<Dusts.Electric2>(), 0.4f, 9);
        */

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
            dust.color.R = 102;
            dust.color.G = 0;
            dust.color.B = 255;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor) => dust.color;

        public override bool Update(Dust dust)
        {
            Lighting.AddLight(dust.position, new Vector3(0.1f, 0f, 0.5f) * 1.5f * dust.scale);
            dust.rotation += Main.rand.NextFloat(2f);
            dust.color *= 0.92f;
            if (dust.color.G > 80) dust.color.G -= 4;

            dust.scale *= 0.92f;
            if (dust.scale < 0.2f)
                dust.active = false;
            return false;
        }
    }

    public class TempusBolt : Electric
    {
        public override bool Update(Dust dust)
        {
            Lighting.AddLight(dust.position, new Vector3(0.1f, 0f, 0.5f) * 1.5f * dust.scale);
            dust.rotation += Main.rand.NextFloat(2f);
            dust.color *= 0.92f;
            if (dust.color.G > 80) dust.color.G -= 4;

            dust.scale *= 0.98f;
            if (dust.scale < 0.1f)
                dust.active = false;
            return false;
        }
    }
}