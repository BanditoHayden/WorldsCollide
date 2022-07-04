using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using WorldsCollide.Dusts;

namespace WorldsCollide.Projectiles.Magic
{
	public class GhostBall : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 60;
		}
		public override void AI()
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.BlueTorch);

			
		}
		public override void Kill(int timeLeft)
		{
			
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Glass, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			
		}

	
	}
}
