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
	public class TroupeBat2 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			Main.projFrames[Projectile.type] = 5;
		}
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

			Projectile.position.X += (float)Math.Sin(Projectile.timeLeft / 6) * 0.5f;
			Projectile.position.Y += (float)Math.Cos(Projectile.timeLeft / 6) * 0.5f;
			if (++Projectile.frameCounter >= 10)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
			Projectile.rotation = Projectile.velocity.ToRotation();

			Projectile.ai[0] += 1f;

		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath4, Projectile.position);

		}


	}
}
