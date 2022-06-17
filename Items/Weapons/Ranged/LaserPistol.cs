using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Ammo;
using Terraria.Audio;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Weapons.Ranged
{
    public class LaserPistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Laser Pistol");
            Tooltip.SetDefault("War never changes");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
           
            Item.UseSound = new SoundStyle($"{nameof(WorldsCollide)}/Assets/Sounds/Items/Guns/LaserPistolFire")
            {
                Volume = 0.9f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 11;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<LaserProj>();
            Item.shootSpeed = 15.7f;
            Item.useAmmo = ModContent.ItemType<FusionCell>();

        }
       
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
        public override void AddRecipes()
        {
                 CreateRecipe()
                .AddIngredient(ModContent.ItemType<Plastic>(), 10)
                .AddIngredient(ItemID.IronBar, 15)
                .AddTile(TileID.Anvils)
                .Register();
            // Alt
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<Plastic>(), 10)
           .AddIngredient(ItemID.LeadBar, 15)
           .AddTile(TileID.Anvils)
           .Register();
        }




    }
}
