using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using skybound.Core;


namespace skybound.Core
{
    public class skyboundPlayer : ModPlayer
    {

        public bool TooHot;
        public int healHurt;

        public int shootDelay = 0;

        public int Shake = 0;
        public bool ScreenMoveHold = false;
        private int panDown = 0;



        public override void ResetEffects()
        {
            TooHot = false;
            healHurt = 0;

            if (Shake > 120 * ModContent.GetInstance<skyboundConfig>().ScreenshakeMult)
                Shake = (int)(120 * ModContent.GetInstance<skyboundConfig>().ScreenshakeMult);
        }

        public override void OnEnterWorld(Player player)
        {
            Shake = 0;

            Main.NewTextMultiline("Thank you for downloading Skybound!\n" +
              "If there is a problem, please report it to the Discord!", c: Color.Lavender);
        }

        public override void ModifyScreenPosition()
        {
            float mult = ModContent.GetInstance<skyboundConfig>().ScreenshakeMult;
            mult *= Main.screenWidth / 2048f; //normalize for screen resolution

            Main.screenPosition.Y += Main.rand.Next(-Shake, Shake) * mult + panDown;
            Main.screenPosition.X += Main.rand.Next(-Shake, Shake) * mult;

            if (Shake > 0)
                Shake--;
        }

        public override void UpdateDead()
        {
            TooHot = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (TooHot)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                // lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
                Player.lifeRegen -= 2;
            }
            if (healHurt > 0)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 120 * healHurt;
            }
        }

        public override void PostUpdate()
        {

            if (shootDelay > 0)
                shootDelay--;
            if (shootDelay == 1)
            {
                Rectangle textPos = new Rectangle((int)Player.position.X, (int)Player.position.Y - 20, Player.width, Player.height);
                CombatText.NewText(textPos, new Color(143, 96, 204), "Cooldown over!");
            }
        }

    }
}