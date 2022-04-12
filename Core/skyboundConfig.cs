using System.ComponentModel;
using skybound;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace skybound.Core
{
	[Label("Client Config")]
	class skyboundConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static skyboundConfig Instance;

		[Label("Screenshake")]
		[Tooltip("Modifies the intensity of screen shake effects")]
		[Range(0, 1)]
		[Slider]
		[DefaultValue(1f)]
		public float ScreenshakeMult = 1;

	}
}