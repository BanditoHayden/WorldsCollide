using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WorldsCollide.Assets.Common
{
	public abstract class BaseIdleHoldoutProjectile : ModProjectile
	{
		public static Dictionary<int, int> ItemProjectileRelationship = new Dictionary<int, int>();

		public Player Owner => Main.player[Projectile.owner];

		public abstract int AssociatedItemID { get; }

		public abstract int IntendedProjectileType { get; }

		public static void LoadAll()
		{
			ItemProjectileRelationship = new Dictionary<int, int>();
			Type[] types = typeof(WorldsCollide).Assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsAbstract && type.IsSubclassOf(typeof(BaseIdleHoldoutProjectile)))
				{
					BaseIdleHoldoutProjectile instance = Activator.CreateInstance(type) as BaseIdleHoldoutProjectile;
					ItemProjectileRelationship[instance.AssociatedItemID] = instance.IntendedProjectileType;
				}
			}
		}

		public static void CheckForEveryHoldout(Player player)
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			foreach (int itemID in ItemProjectileRelationship.Keys)
			{
				Item heldItem = player.ActiveItem();
				if (heldItem.type != itemID)
				{
					continue;
				}
				bool bladeIsPresent = false;
				int holdoutType = ItemProjectileRelationship[itemID];
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].type == holdoutType && Main.projectile[i].owner == ((Entity)player).whoAmI && ((Entity)Main.projectile[i]).active)
					{
						bladeIsPresent = true;
						break;
					}
				}
				if (Main.myPlayer == ((Entity)player).whoAmI && !bladeIsPresent)
				{
					StatModifier val = player.GetTotalDamage(heldItem.DamageType);
					int damage = (int)val.ApplyTo((float)heldItem.damage);
					val = player.GetTotalKnockback(heldItem.DamageType);
					float kb = val.ApplyTo(heldItem.knockBack);
					Projectile.NewProjectile(((Entity)player).GetSource_ItemUse(heldItem, (string)null), ((Entity)player).Center, Vector2.Zero, holdoutType, damage, kb, ((Entity)player).whoAmI, 0f, 0f);
				}
			}
		}

		public sealed override void AI()
		{
			CheckForEveryHoldout(Owner);
			if (Owner.ActiveItem().type != AssociatedItemID || Owner.CCed || !((Entity)Owner).active || Owner.dead)
			{
				Projectile.Kill();
			}
			else
			{
				SafeAI();
			}
		}

		public virtual void SafeAI()
		{
		}
	}


}