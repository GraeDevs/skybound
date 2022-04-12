using System;
using Terraria;
using Terraria.ModLoader;


namespace skybound.Core
{
    public class skyboundGlobalNPC : GlobalNPC
    {
        public Entity attacker = Main.LocalPlayer;

        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;
    }
}
