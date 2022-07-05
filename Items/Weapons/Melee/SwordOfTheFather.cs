using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WorldsCollide.Buffs;

namespace WorldsCollide.Items.Weapons.Melee
{
    public class SwordOfTheFather : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Killing enemies empowers the sword");
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
            if (npc.life <= 0)
            {
               // player.AddBuff(ModContent.BuffType<Empowered>(), 180, true);
            }
        }
       
    }

}
