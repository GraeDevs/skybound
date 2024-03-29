﻿using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace skybound.Core
{
    public class TileRunner
    {
        public Vector2 pos;
        public Vector2 speed;
        public Point16 hRange;
        public Point16 vRange;
        public double strength;
        public double str;
        public int steps;
        public int stepsLeft;
        public ushort type;
        public bool addTile;
        public bool overRide;

        public TileRunner(Vector2 pos, Vector2 speed, Point16 hRange, Point16 vRange, double strength, int steps, ushort type, bool addTile, bool overRide)
        {
            this.pos = pos;
            if (speed.X == 0 && speed.Y == 0)
            {
                this.speed = new Vector2(WorldGen.genRand.Next(hRange.X, hRange.Y + 1) * 0.1f, WorldGen.genRand.Next(vRange.X, vRange.Y + 1) * 0.1f);
            }
            else
            {
                this.speed = speed;
            }
            this.hRange = hRange;
            this.vRange = vRange;
            this.strength = strength;
            str = strength;
            this.steps = steps;
            stepsLeft = steps;
            this.type = type;
            this.addTile = addTile;
            this.overRide = overRide;
        }

        public void Start()
        {
            while (str > 0 && stepsLeft > 0)
            {
                str = strength * (double)stepsLeft / steps;

                PreUpdate();

                int a = (int)Math.Max(pos.X - str * 0.5, 1);
                int b = (int)Math.Min(pos.X + str * 0.5, Main.maxTilesX - 1);
                int c = (int)Math.Max(pos.Y - str * 0.5, 1);
                int d = (int)Math.Min(pos.Y + str * 0.5, Main.maxTilesY - 1);

                for (int i = a; i < b; i++)
                {
                    for (int j = c; j < d; j++)
                    {
                        if (Math.Abs(i - pos.X) + Math.Abs(j - pos.Y) >= strength * StrengthRange())
                            continue;
                        ChangeTile(Main.tile[i, j]);
                    }
                }

                str += 50;
                while (str > 50)
                {
                    pos += speed;
                    stepsLeft--;
                    str -= 50;
                    speed.X += WorldGen.genRand.Next(hRange.X, hRange.Y + 1) * 0.05f;
                    speed.Y += WorldGen.genRand.Next(vRange.X, vRange.Y + 1) * 0.05f;
                }

                speed = Vector2.Clamp(speed, new Vector2(-1, -1), new Vector2(1, 1));

                PostUpdate();
            }
        }

        public virtual void ChangeTile(Tile tile)
        {
            if (type == 0)
            {
                tile.HasTile = true;
                return;
            }
            if (overRide || !tile.HasTile)
                tile.TileType = type;
            if (addTile)
            {
                tile.HasTile = true;
                tile.LiquidType = 0;
            }
        }

        public virtual double StrengthRange()
        {
            return 0.5 + WorldGen.genRand.Next(-10, 11) * 0.0075;
        }

        public virtual void PreUpdate()
        {

        }

        public virtual void PostUpdate()
        {

        }

        public static void TunnelRunner(int x, int y, int tileType, int Length, int Thickness, int Intensity, bool wet, bool PlaceTile)
        {
            int PositionX = x;
            int PositionY = y;

            int tunnellength = Length;

            bool Left = false;
            if (Main.rand.Next(2) == 0)
            {
                Left = true;
            }
            if (Left)
            {
                for (int TunnelX = PositionX; TunnelX > PositionX - tunnellength; TunnelX--)
                {
                    WorldGen.digTunnel(TunnelX + 20, PositionY, 0, 0, Intensity, Thickness, wet);

                    if (PlaceTile)
                    {
                        WorldGen.TileRunner(TunnelX + 20, PositionY, Thickness + 20, Intensity, tileType, false, 0f, 0f, false, true);
                    }
                }
            }
            else
            {
                for (int TunnelX = PositionX; TunnelX < PositionX + tunnellength; TunnelX++)
                {
                    WorldGen.digTunnel(TunnelX - 20, PositionY, 0, 0, Intensity, Thickness, wet);

                    if (PlaceTile)
                    {
                        WorldGen.TileRunner(TunnelX - 20, PositionY, Thickness + 20, Intensity, tileType, false, 0f, 0f, false, true);
                    }
                }
            }
        }
    }
}