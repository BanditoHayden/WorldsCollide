using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using WorldsCollide.Dusts;
using Microsoft.Xna.Framework.Graphics;

namespace WorldsCollide.Projectiles.Magic
{
	public class Oracle : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 120;
			Projectile.extraUpdates = 2;
			Projectile.light = 1f;
		}
		public override void AI()
		{

			Projectile.rotation += 0.4f * (float)Projectile.direction;

		}
		int dust = Dust.NewDust(new Vector2(), 1, 1, 58, 0, 0, 100, default, 1f);// use for dust id

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 180; i++)
			{
				Vector2 dustPos = Projectile.Center + new Vector2(46, 0).RotatedBy(MathHelper.ToRadians(i * 2));
				Dust dust = Dust.NewDustPerfect(dustPos, DustID.Enchanted_Pink);
				dust.noGravity = true;
			}
		}
       
	}
	
	
}