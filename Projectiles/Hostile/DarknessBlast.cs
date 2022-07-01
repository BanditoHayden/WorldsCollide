using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using WorldsCollide.Dusts;

namespace WorldsCollide.Projectiles.Hostile
{
    public class DarknessBlast : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.timeLeft = 180;


            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.Pi;

            }

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Obstructed, 240, true);
            }
            if (Main.masterMode)
            {
                target.AddBuff(BuffID.Obstructed, 300, true);
            }
            else
                target.AddBuff(BuffID.Obstructed, 180, true);
        }
    }
}
