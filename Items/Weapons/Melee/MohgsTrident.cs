
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Melee;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class MohgsTrident : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("");

            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            // Item.rare = ModContent.RarityType<testrarity>();
            Item.rare = 2;
            Item.value = Item.sellPrice(silver: 10);
            Item.width = 60;
            Item.height = 60;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item71;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.useTime = 50;
            Item.useAnimation = 50;
            // Weapon Properties
            Item.damage = 32;
            Item.knockBack = 4f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<MohgsTridentProjectile>();
            Item.shootSpeed = 3.7f;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }
        public override bool? UseItem(Player player)
        {
            // Because we're skipping sound playback on use animation start, we have to play it ourselves whenever the item is actually used.
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }
    }
}
