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
	public class WeirdEyl : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 120;
		}

        public override void AI()
        {

			var waveVelocity = new Vector2((float)Math.Cos(Projectile.ai[0]), (float)Math.Sin(Projectile.ai[0]));
			Projectile.position.X += (float)Math.Sin(Projectile.timeLeft / 6) * 0.5f;
			Projectile.position.Y += (float)Math.Cos(Projectile.timeLeft / 6) * 0.5f;


			Projectile.ai[0] += 1f;
            
        }

        public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath23, Projectile.position);
			for (int k = 0; k < 16; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Blood, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
		}

		
	}
}
