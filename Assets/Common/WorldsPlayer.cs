using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;

namespace WorldsCollide.Assets.Common
{
    public class WorldsPlayer : ModPlayer
    {
        public bool Pickaxe = false;
        public bool StrengthMedallion;
        public bool Diplopia;
        public bool Bumble;
        public override void ResetEffects()
        {
            StrengthMedallion = false;
            Diplopia = false;
            Bumble = false;
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (Helpers.Sets.IsAGreatsword[item.type])
            {
                if (StrengthMedallion)
                {
                    damage += 0.1f;

                }
            }
        }
        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Bumble && item.CountsAsClass(DamageClass.Ranged))
            {
                const int NumProjectiles = 1;
                if (Player.strongBees)
                {
                    if (Main.rand.NextBool(15))
                    {
                        for (int i = 0; i < NumProjectiles; i++)
                        {
                            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                            newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                            Projectile.NewProjectile(source, position, velocity, ProjectileID.GiantBee, damage, knockback, Player.whoAmI);

                        }
                    }
                }
                else
                if (Main.rand.NextBool(10))
                {
                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                        Projectile.NewProjectile(source, position, velocity, ProjectileID.Bee, damage, knockback, Player.whoAmI);

                    }
                }

            }
            return true;
        }

    }
}
