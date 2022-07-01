using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;


namespace WorldsCollide.Projectiles.Melee
{
	public class Nether2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			
		}
		int timer;
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 34;
			Projectile.aiStyle = 1;
			Projectile.friendly = false;

			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 120;
			Projectile.light = 0.5f;
			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 1;
			AIType = ProjectileID.WoodenArrowFriendly;
		}
		public override void AI()
		{
			timer++;
			if (timer >= 30)
			{
				Projectile.friendly = true;
			}
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);

			}
		}
		
	}
}
