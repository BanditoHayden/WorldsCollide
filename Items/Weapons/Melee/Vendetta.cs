using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class Vendetta : ModItem
    {
        int currentAttack = 1;
        int fired;

        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("[c/8b0000:It is designed to resemble Death's scythe]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Master;

            Item.width = 60;
            Item.height = 60;
            Item.scale = 1.3f;
            Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 30;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<VendettaHeld>();
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            fired++;
            int dir = currentAttack;
            currentAttack = -currentAttack;
            if (fired < 3)
            {
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, dir);
            }
            if (fired == 3)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<VendettaHeld2>(), damage, knockback, player.whoAmI);
                fired = 0;
            }
            return false;
        }



    }
}
