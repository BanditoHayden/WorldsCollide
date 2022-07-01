using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using WorldsCollide.Dusts;

namespace WorldsCollide.Projectiles.Hostile
{
    public class CursedBlast : ModProjectile
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
           

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Cursed, 240, true);
            }
            if (Main.masterMode)
            {
                target.AddBuff(BuffID.Cursed, 300, true);
            }
            else
                target.AddBuff(BuffID.Cursed, 180, true);
        }
    }
}
