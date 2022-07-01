using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class NetheriteShortsword : ModItem
    {
        int fired;
        public override void SetStaticDefaults()
        {
            
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 1f;
            Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = false;
            Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item

            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.shoot = ModContent.ProjectileType<NetherProjectile>(); // The projectile is what makes a shortsword work
            Item.shootSpeed = 3f; // This value bleeds into the behavior of the projectile as velocitelocity, keep that in mind when tweaking values
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            fired++;
            Main.NewText(fired);
           if (fired < 9)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1);
            }
            if (fired == 9)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                newVelocity *= 2f - Main.rand.NextFloat(0.3f);
                const int NumProjectiles = 6;
                for (int i = 0; i < NumProjectiles; i++)
                {
                    Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<Nether2>(), damage, knockback, player.whoAmI);
                }
                fired = 0;
            }
            return false;
        }
        
    }
    
}
