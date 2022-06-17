using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent;
using WorldsCollide.Dusts;
using System;
using System.Collections.Generic;

namespace WorldsCollide.Projectiles.Melee
{
    public class GracefulDahliaHeld : ModProjectile
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
            Projectile.scale = 1.3f;
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

            float defRot = Projectile.velocity.ToRotation();

            float start = defRot - ((MathHelper.PiOver2) - 0.2f);

            float end = defRot + ((MathHelper.PiOver2) - 0.2f);

            float rotation = dir == 1 ? start.AngleLerp(end, swingProgress) : start.AngleLerp(end, 1f - swingProgress);

            Vector2 position = player.RotatedRelativePoint(player.MountedCenter);
            position += rotation.ToRotationVector2() * holdOffset;
            Projectile.Center = position;
            Projectile.rotation = (position - player.Center).ToRotation() + MathHelper.PiOver4;
            player.ChangeDir(Projectile.velocity.X < 0 ? -1 : 1);
            player.itemRotation = rotation * player.direction;
            player.itemTime = 2;
            player.itemAnimation = 2;
            Projectile.netUpdate = true;
            if (Projectile.spriteDirection == -1)
            {
                Projectile.position.Y = player.MountedCenter.Y - (float)(Projectile.height / 2) - 90;

            }
        }
       
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)

        {
            overPlayers.Add(index);
        }
    }
}
