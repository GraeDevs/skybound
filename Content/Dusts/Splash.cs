using skybound.Core;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace skybound.Content.Dusts
{
    public abstract class Splash : ModDust
    {
        public override string Texture => "skybound/Content/Dusts/BastionSpark";

        public override void SetStaticDefaults()
        {
            UpdateType = 33;
        }

        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170;
            dust.velocity *= 0.5f;
            dust.velocity.Y += 1f;
        }
    }

    public abstract class Oil : Splash
    {
        public override string Texture => "skybound/Content/Dusts/BastionSpark";

        public override void SetStaticDefaults()
        {
            UpdateType = 33;
            
        }

        public override void OnSpawn(Dust dust)
        {
            dust.color = new Color(255, 255, 255);
            dust.alpha = 170;
            dust.velocity *= 0.5f;
            dust.velocity.Y += 1f;
        }
    }
}