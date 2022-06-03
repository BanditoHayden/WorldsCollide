using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
namespace WorldsCollide.Projectiles.Magic
{
	public class Roy : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.friendly = true;
			Projectile.penetrate = -1;


			Projectile.timeLeft = 5;


		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{

			if (Main.expertMode)
			{
				if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
				{
					damage /= 5;
				}
			}
		}
		public override void AI()
		{
			if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
			{
				Projectile.tileCollide = false;
				
				Projectile.alpha = 255;
				Projectile.position = Projectile.Center;
				//projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				Projectile.width = 250;
				Projectile.height = 250;
				Projectile.Center = Projectile.position;
				//projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				//projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
				Projectile.damage = 20;
				Projectile.knockBack = 10f;
			}
			
			return;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Projectile.Kill();
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

			// Smoke Dust spawn
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			// Fire Dust spawn
			for (int i = 0; i < 80; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
			}

		}
		
		
	}
	


		
}

