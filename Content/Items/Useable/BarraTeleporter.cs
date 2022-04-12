using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using skybound.Content.Subworlds.Barra;
using skybound;
using Terraria.ID;
using skybound.Core;
using SubworldLibrary;

namespace skybound.Content.Items.Useable
{
    public class BarraTeleporter : ModItem
    {
        public override string Texture => "skybound/Placeholder";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Teleports the user to and from Barra");
        }
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.rare = ItemRarityID.Purple;
            Item.value = 100000;
            Item.maxStack = 1;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item6;
        }

        public override bool CanUseItem(Player player)
        {
            if(!SubworldSystem.AnyActive(skybound.instance))
            {
                SubworldSystem.Enter<Barra>();
            }
            else
            {
                SubworldSystem.Exit();
            }
            return true;
        }
    }
}
