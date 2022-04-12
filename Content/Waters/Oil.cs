using Microsoft.Xna.Framework;
using skybound.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.Waters
{
    public class Oil : ModWaterStyle
    {
        public override string Texture => "skybound/Content/Waters/Oil";
        public override string BlockTexture => "skybound/Content/Waters/OilBlock";

        public override int ChooseWaterfallStyle() => ModContent.GetInstance<WaterfallOil>().Slot;

        public override int GetDropletGore() => 0;

        public override int GetSplashDust() =>
          DustType<Dusts.Splash>();

        public override Color BiomeHairColor() => new Color(255, 255, 255);
    }

    public class WaterfallOil : ModWaterfallStyle
    {
        public override string Texture => "skybound/Content/Waters/OilWaterfallStyle";
    }
}
