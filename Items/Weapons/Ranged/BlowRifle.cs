using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Ammo;
using WorldsCollide.Items.Materials;
using Terraria.DataStructures;

namespace WorldsCollide.Items.Weapons.Ranged
{
    public class BlowRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Tooltip.SetDefault("Uses seeds for ammo");

        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Green;
            Item.width = 30;
            Item.height = 30;
            // Use Properties
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item63;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 15;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Seed;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Dart;
            Item.scale = 1.2f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           
           .AddIngredient(ItemID.Blowpipe, 1)
            .AddIngredient(ItemID.HellstoneBar, 7)
                .AddIngredient(ItemID.IllegalGunParts, 7)
           .AddTile(TileID.Anvils)
           .Register();
        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}
