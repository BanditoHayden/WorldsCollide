using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide.Projectiles.Melee
{
	public class StormProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 3.5f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 200f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15f;
		}
		public override void SetDefaults()
		{
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
	
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			
		Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Cloud, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			
		}
	}
}