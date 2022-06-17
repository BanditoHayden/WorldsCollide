using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.Collections.Generic;
using Terraria.GameContent;

namespace WorldsCollide.Projectiles.Melee
{
    public class BigHammerHeld : ModProjectile
    {
        public int SwingTime = 60;  //increase this, if the swing time is 0, Projectile.timeLeft is also 0

        public float holdOffset = 45f;
        public override void SetDefaults()

        {
            Projectile.timeLeft = SwingTime; //as you can see here
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.height = 60;
            Projectile.width = 60;
            Projectile.friendly = true;
            Projectile.scale = 1.2f;
        }
        public virtual float Lerp(float val)
        {
            return val == 1f ? 1f : (val == 0f ? 0f : (float)Math.Pow(2, val * 10f - 10f) / 2f);
        }

        public override void AI()
        {
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10000;

            AttachToPlayer();
        }

        public override bool ShouldUpdatePosition() => false;
        public void AttachToPlayer() // the actual AI
        {
            Player player = Main.player[Projectile.owner];
            if (!player.active || player.dead || player.CCed || player.noItems) //Kills the projectile if one of these conditions are met
            {
                return;
            }

            int dir = (int)Projectile.ai[1]; //stands for direction
            float swingProgress = Lerp(Utils.GetLerpValue(0f, SwingTime, Projectile.timeLeft));
            // the actual rotation it should have
            float defRot = Projectile.velocity.ToRotation();
            // starting rotation
            float start = defRot - ((MathHelper.PiOver2) - 0.2f);
            // ending rotation
            float end = defRot + ((MathHelper.PiOver2) - 0.2f);
            // current rotation 
            float rotation = dir == 1 ? start.AngleLerp(end, swingProgress) : start.AngleLerp(end, 1f - swingProgress);
            // offsetted cuz sword sprite
            Vector2 position = player.RotatedRelativePoint(player.MountedCenter);
            position += rotation.ToRotationVector2() * holdOffset;
            Projectile.Center = position;
            Projectile.rotation = (position - player.Center).ToRotation() + MathHelper.PiOver4;
            player.ChangeDir(Projectile.velocity.X < 0 ? -1 : 1);  //stuff to let the projectile spawning of the weapon work properly and the hand movement 
            player.itemRotation = rotation * player.direction;
            player.itemTime = 2;
            player.itemAnimation = 2;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {

            overPlayers.Add(index);
        }
    }
}
