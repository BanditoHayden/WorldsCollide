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

			var waveVelocity = new Vector2((float)Math.Cos(Projectile.ai[0]), (float)Math.Sin(Projectile.ai[0]));
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
			int Dusty = Dust.NewDust(Projectile.position, 15, 15, DustID.CrimsonTorch, 0f, 0f, 100, new Color(0, 200, 0), 1f);
			Dust obj = Main.dust[Dusty];
			obj.noGravity = true;
			obj.position.X -= Projectile.velocity.X * 0.2f;
			obj.position.Y += Projectile.velocity.Y * 0.2f;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			for (int i = 0; i < 3; i++)
			{
				
				Dust dusty = Dust.NewDustPerfect(Projectile.position, DustID.RedMoss, Scale: 0.7f);
			}
		}

        public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath4, Projectile.position);
			for (int i = 0; i < 50; i++)
			{
				Vector2 outerdustring = Main.rand.NextVector2CircularEdge(1f, 1f);
				Dust dusty = Dust.NewDustPerfect(Projectile.position, DustID.RedMoss, outerdustring * 5, Scale: 1.5f);
				dusty.noGravity = true;
			}
		}


	}
}
