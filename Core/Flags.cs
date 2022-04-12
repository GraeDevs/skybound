using System;
using System.Linq;
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using skybound.Content.Tiles;
using skybound.Core;

namespace skybound.Core
{
    public sealed partial class Flags : ModSystem
    {
        public static int puzzlePosts;
        public static bool bastionUnlocked = false;
        public static bool bastionPuzzleComplete = false;

        public int timer = 0;

        public override void PostUpdateWorld()
        {
            skyboundPlayer shake = Main.LocalPlayer.GetModPlayer<skyboundPlayer>();
            if (puzzlePosts == 1)
            {
                if(!bastionUnlocked)
                {
                    timer++;
                    if (timer <= 1)
                        Main.NewText("I'd be careful if I were you..", 82, 3, 252);
                                        
                    if (timer < 50) 
                        shake.Shake += 2;
                    
                    if(timer == 50)
                        bastionUnlocked = true;
                    
                }
            }
        }
        public override void OnWorldLoad()
        {
            bastionUnlocked = false;
            bastionPuzzleComplete = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (bastionUnlocked)
                tag["bastionUnlocked"] = true;
            if (bastionPuzzleComplete)
                tag["bastionPuzzleComplete"] = true;
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = bastionUnlocked;
            flags[1] = bastionPuzzleComplete;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            bastionUnlocked = flags[0];
            bastionPuzzleComplete = flags[1];
        }
    }
}
