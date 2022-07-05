using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Content;
using ReLogic.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.UI.Chat;

public static class WorldsCollideUtils
{
	public static Item ActiveItem(this Player player)
	{
		if (!Main.mouseItem.IsAir)
		{
			return Main.mouseItem;
		}
		return player.HeldItem;
	}
	public static T ModProjectile<T>(this Projectile projectile) where T : ModProjectile
	{
		ModProjectile modProjectile = projectile.ModProjectile;
		return (T)(object)((modProjectile is T) ? modProjectile : null);
	}
}