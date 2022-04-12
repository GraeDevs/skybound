using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using skybound.Core;

namespace skybound.Core
{
    public sealed partial class skyboundWorld : ModSystem
    {
        public static float rottime;
        public static int Timer;

        public override void PreUpdateWorld()
        {
            Timer++;
            rottime += (float)Math.PI / 60;
            if (rottime >= Math.PI * 2) rottime = 0;

        }
    }
}