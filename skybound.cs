using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.Localization;
using skybound.Core;


namespace skybound
{
    public class skybound : Mod
    {
        public static Mod SubworldLibrary;
        public static skybound instance => ModContent.GetInstance<skybound>();
        public static skybound Instance { get; set; }
        public static skybound Mod { get; set; }

        public skybound()
        {
            Instance = this;

            Mod = this;

        }


        public override void Load()
        {
            if (!Main.dedServ)
            {
            }

        }

        public override void Unload()
        {
        }
    }
}