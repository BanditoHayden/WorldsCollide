using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using WorldsCollide.Projectiles.Ranged;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Ammo
{
	public class FireworkArrow : ModItem
	{
		public override void SetStaticDefaults()
		{


			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.width = 14;
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 2f;
			Item.value = 100;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.RocketFireworkRed;
			Item.shootSpeed = 3f;
			Item.ammo = AmmoID.Arrow;
		}
	

	}
}
