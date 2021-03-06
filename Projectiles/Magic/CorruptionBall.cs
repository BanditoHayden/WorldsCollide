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
	public class CorruptionBall : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 60;
		}
		public override void AI()
		{
			Projectile.velocity.Y += Projectile.ai[0];

			for (int k = 0; k < 2; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CorruptGibs, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);

			}
		}
		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CorruptGibs, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}
