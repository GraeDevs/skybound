using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using skybound.Content.NPCs.Cathedral;
using skybound.Core;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace skybound.Content.Tiles.Cathedral
{
    internal class SmallCathedralTrapTile : ModTile
    {
        public override string Texture => "skybound/Empty";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileFrameImportant[Type] = false;
            DustType = ModContent.DustType<Dusts.CathedralDust>();
            AddMapEntry(new Color(81, 77, 71));
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if(Flags.bastionUnlocked == true)
            {
                if(Flags.bastionPuzzleComplete == false)
                {

                    Vector2 pos = new Vector2(4 + i * 16, 4 + j * 16);
                    if (!Main.npc.Any(NPC => NPC.type == NPCType<SmallCathedralTrap>() && (NPC.ModNPC as SmallCathedralTrap).Parent == Main.tile[i, j] && NPC.active))
                    {
                        int Trap = NPC.NewNPC(new EntitySource_WorldEvent(), (int)pos.X + 4, (int)pos.Y + 21, NPCType<SmallCathedralTrap>());
                        if (Main.npc[Trap].ModNPC is SmallCathedralTrap) (Main.npc[Trap].ModNPC as SmallCathedralTrap).Parent = Main.tile[i, j];
                    }
                }
            }
        }
    }

    public class SmallCathedralTrapItem : ModItem
    {
        public override string Texture => "skybound/Placeholder";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Cathedral Trap");
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.rare = 2;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Cathedral.SmallCathedralTrapTile>();
        }
    }
}