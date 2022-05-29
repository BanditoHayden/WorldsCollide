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
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 3;
			Projectile.tileCollide = false;
			
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.timeLeft = 200;
			
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
			float maxDetectRadius = 800f; // The maximum radius at which a projectile can detect a target
			float projSpeed = 5f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
			
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			
		}
        public override void Kill(int timeLeft)
        {
			SoundStyle style = new SoundStyle($"{nameof(WorldsCollide)}/Assets/Sounds/Items/Guns/Sheathe") with { Volume = .99f, };
			SoundEngine.PlaySound(style);
			Filters.Scene["Shockwave"].Deactivate();
		}


    }
}
