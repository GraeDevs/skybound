using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.Graphics.Light;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ObjectData;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using skybound.Core;

namespace skybound.Core
{
    public static class skyboundUtils
    {
        public static Vector2 TileAdj => (Lighting.Mode == Terraria.Graphics.Light.LightMode.Retro || Lighting.Mode == Terraria.Graphics.Light.LightMode.Trippy) ? Vector2.Zero : Vector2.One * 12;

        public static Vector2 ScreenSize => new Vector2(Main.screenWidth, Main.screenHeight);

        public static T GetFieldValue<T>(this Type type, string fieldName, object obj = null, BindingFlags? flags = null)
        {
            if (flags == null)
            {
                flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
            }
            FieldInfo field = type.GetField(fieldName, flags.Value);
            return (T)field.GetValue(obj);
        }

        public static void Bolt(Vector2 point1, Vector2 point2, int dusttype, float scale = 1, int armLength = 30, Color color = default, float frequency = 0.05f)
        {
            int nodeCount = (int)Vector2.Distance(point1, point2) / armLength;
            Vector2[] nodes = new Vector2[nodeCount + 1];

            nodes[nodeCount] = point2; //adds the end as the last point

            for (int k = 1; k < nodes.Length; k++)
            {
                //Sets all intermediate nodes to their appropriate randomized dot product positions
                nodes[k] = Vector2.Lerp(point1, point2, k / (float)nodeCount) +
                    (k == nodes.Length - 1 ? Vector2.Zero : Vector2.Normalize(point1 - point2).RotatedBy(1.58f) * Main.rand.NextFloat(-armLength / 2, armLength / 2));

                //Spawns the dust between each node
                Vector2 prevPos = k == 1 ? point1 : nodes[k - 1];
                for (float i = 0; i < 1; i += frequency)
                {
                    Dust.NewDustPerfect(Vector2.Lerp(prevPos, nodes[k], i), dusttype, Vector2.Zero, 0, color, scale);
                }
            }
        }
        public static void ObjectPlace(Point Origin, int x, int y, int TileType, int style = 0, int direction = -1)
        {
            WorldGen.PlaceObject(Origin.X + x, Origin.Y + y, TileType, true, style, 0, -1, direction);
            NetMessage.SendObjectPlacment(-1, Origin.X + x, Origin.Y + y, TileType, style, 0, -1, direction);
        }
        public static void ObjectPlace(int x, int y, int TileType, int style = 0, int direction = -1)
        {
            WorldGen.PlaceObject(x, y, TileType, true, style, 0, -1, direction);
            NetMessage.SendObjectPlacment(-1, x, y, TileType, style, 0, -1, direction);
        }
        public static skyboundPlayer GetSkyboundPlayer(this Player player) => player.GetModPlayer<skyboundPlayer>();
    }
}
