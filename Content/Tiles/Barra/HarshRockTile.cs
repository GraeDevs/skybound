﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using skybound.Content.Dusts;

namespace skybound.Content.Tiles.Barra
{
    public class HarshRockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = 12;
            SoundType = 21;
            SoundStyle = 2;
            MineResist = 1f;
            MinPick = 2;
            AddMapEntry(new Color(102, 59, 66));
            ItemDrop = ModContent.ItemType<Content.Items.Placeable.Tiles.Barra.HarshRock>();
        }
    }
}