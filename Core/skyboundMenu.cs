using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ReLogic.Content;
using Terraria.ModLoader;
namespace skybound.Core
{
    internal class skyboundMenu : ModMenu
    {

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
        {
            logoDrawCenter -= new Vector2(0, 0);
            logoScale = 1f;
            return true;
        }

        public override void Update(bool isOnTitleScreen)
        {
            Main.dayTime = true;
            Main.time = 40000;
        }

        public override string DisplayName => "Skybound";
        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("skybound/MenuLogo");
        public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<Content.Backgrounds.SkyboundMenu>();

    }
}
