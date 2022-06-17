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
	public class TroupesEmbers : ModItem
	{
		int fired;
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Troupe's Embers");

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
			Item.UseSound = SoundID.NPCHit21;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TroupeBat2>();
			Item.shootSpeed = 7f;

			Item.mana = 10;
		}

	}
}
