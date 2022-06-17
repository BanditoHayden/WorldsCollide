using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class RedQueen : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("[c/fb8b23:Pray for Your Own Savior you’re gonna need it.]");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Red;
            Item.width = 30;
            Item.height = 30;
            Item.scale = 1.0f;
            // Use Properties
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item18;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 19;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties

        }
        
        public override void OnHitNPC(Player player, NPC npc, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(4))
            {
                npc.AddBuff(BuffID.OnFire, 180, false);
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 6, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, default, 1.9f);
            Main.dust[dust].noGravity = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
        
           .AddIngredient(ItemID.DemoniteBar, 14)
            .AddIngredient(ItemID.Obsidian, 30)
           .AddTile(TileID.Anvils)
           .Register();
        }
    }

}
