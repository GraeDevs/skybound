using System;
using skybound.Content.Tiles.Cathedral;
using Terraria.ModLoader;
using skybound.Content.Tiles.Barra;

namespace skybound.Core
{
	public class TileCount : ModSystem
	{
		public int bastionTileCount;

		//Planets
		public int barraCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			bastionTileCount = tileCounts[ModContent.TileType<CathedralBrickTile>()];
			barraCount = tileCounts[ModContent.TileType<DustTile>()];
		}
	}
}