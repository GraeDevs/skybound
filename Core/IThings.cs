using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using skybound.Core;

namespace skybound
{
	/// <summary>
	/// Inspired from other mod structures, this is to be able to centralize content loading.
	/// </summary>
	/// 
	interface IOrderedLoadable
	{
		void Load();
		void Unload();
		float Priority { get; }
	}

	public class HookGroup : IOrderedLoadable
	{
		public virtual SafetyLevel Safety => SafetyLevel.Severe;

		public virtual float Priority { get => 1f; }

		public virtual void Load() { }

		public virtual void Unload() { }
	}

	/// <summary>
	/// Rules:
	/// 1. IL should never be anything lower than Questionable
	/// 2. When in doubt, pick the higher rating (more dangerous)
	/// 3. If possible, leave a short comment explaining the rating of the hook group
	/// </summary>
	public enum SafetyLevel
	{
		Safe = 0,
		Questionable = 1,
		Fragile = 2,
		Severe = 3
	}
}