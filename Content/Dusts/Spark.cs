using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace skybound.Content.Dusts
{
    public class BastionSpark : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
            dust.color.R = 196;
            dust.color.G = 200;
            dust.color.B = 255;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor) => dust.color;

        public override bool Update(Dust dust)
        {
            Lighting.AddLight(dust.position, new Vector3(0.1f, 0.35f, 0.5f) * 1.5f * dust.scale);
            dust.rotation += Main.rand.NextFloat(2f);
            dust.color *= 0.92f;
            if (dust.color.G > 80) dust.color.G -= 4;

            dust.scale *= 0.92f;
            if (dust.scale < 0.15f)
                dust.active = false;
            return false;
        }
    }

    public class Spark2 : BastionSpark
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            Vector3 vector = Vector3.Lerp(Color.White.ToVector3(), dust.color.ToVector3(), 1 - dust.scale);
            return new Color(vector.X, vector.Y, vector.Z) * dust.scale;
        }

        public override bool Update(Dust dust)
        {
            Lighting.AddLight(dust.position, dust.color.ToVector3() * dust.scale);
            dust.rotation += Main.rand.NextFloat(2f);

            dust.scale *= 0.92f;
            if (dust.scale < 0.1f)
                dust.active = false;
            return false;
        }
    }
}
