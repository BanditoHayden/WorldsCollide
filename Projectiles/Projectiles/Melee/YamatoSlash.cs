using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using WorldsCollide.Dusts;

namespace WorldsCollide.Projectiles.Melee
{
	public class YamatoSlash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yam");

		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.penetrate = 1;
			Projectile.aiStyle = 0;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.timeLeft = 200;
			Projectile.light = 0.5f;	
		}
		public override void AI()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				Filters.Scene.Activate("Shockwave", Projectile.Center).GetShader().UseColor(10, 10, 4).UseTargetPosition(Projectile.Center);
			}
			if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
			{
				float progress = (180f - Projectile.timeLeft) / 60f;
				Filters.Scene["Shockwave"].GetShader().UseProgress(1).UseOpacity(500);
			}
			
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<YamatoDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);

			}
			Vector2 vel = Vector2.Zero;
			Vector2 perturbedSpeed = Vector2.Zero;
			//Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position.X, Projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<YamatoSlash2>(), 100, 0f, Projectile.owner);
			Projectile.NewProjectile(Projectile.GetSource_Death(), target.position.X, target.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<YamatoSlash2>(), 100, 0f, Projectile.owner);
		}
        public override void Kill(int timeLeft)
        {
			SoundStyle style = new SoundStyle($"{nameof(WorldsCollide)}/Assets/Sounds/Items/Guns/Sheathe") with { Volume = .99f, };
			SoundEngine.PlaySound(style);
			
			Filters.Scene["Shockwave"].Deactivate();
			
		}


    }
}
