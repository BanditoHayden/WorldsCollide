using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using WorldsCollide.Projectiles.Magic;
using Terraria.Audio;

namespace WorldsCollide.Items.Weapons.Magic
{
    public class Curser : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Curser");
			Tooltip.SetDefault("Spawn explosions at your cursor");
            
        }
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 50;
			Item.useAnimation = 50;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; 
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = new SoundStyle($"{nameof(WorldsCollide)}/Assets/Sounds/Items/Guns/Snap")
			{
				Volume = 1f,
				PitchVariance = 0.0f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Roy>();
			Item.shootSpeed = 0; 
			Item.mana = 11; 
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			
			position = Main.MouseWorld;
		}

	}
}
