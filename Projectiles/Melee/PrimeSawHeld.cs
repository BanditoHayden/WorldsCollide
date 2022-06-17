using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.Collections.Generic;
using Terraria.GameContent;

namespace WorldsCollide.Projectiles.Melee
{
    public class PrimeSawHeld : ModProjectile
    {
		public override void SetStaticDefaults()
		{
		
		}
		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true; //so you can't hit enemies through walls
			Projectile.hide = true; //aiStyle 20 assigns heldProj
			Projectile.DamageType = DamageClass.Melee;

		}
        public override void AI()
        {
			Player player = Main.player[Projectile.owner];

			Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
			Projectile.Center = playerCenter + Projectile.velocity;
		}
    }
}
