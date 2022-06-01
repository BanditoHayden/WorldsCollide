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
    public class YamatoSlash2 : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yam");
			Main.projFrames[Projectile.type] = 4;

		}

		public override void SetDefaults()
		{
			Projectile.width = 70;
			Projectile.height = 70;
			Projectile.penetrate = -1;
			Projectile.aiStyle = 0;
			Projectile.tileCollide = false;

			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.timeLeft = 60;

		}
        public override void AI()
        {
			Projectile.velocity = Vector2.Zero;
			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
		}






    }
}
