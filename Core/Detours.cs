using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;
using MonoMod.RuntimeDetour.HookGen;
using skybound.Core;
namespace skybound.Core
{
    public static class Detours
    {
        public static void Initialize()
        {
        }

        public static void Unload()
        {
        }
    }
}