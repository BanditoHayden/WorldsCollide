using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.Audio;
using WorldsCollide.Npcs.Bosses;
using WorldsCollide.Items.Materials;

namespace WorldsCollide.Items.Consumables
{
    public class GhostlySkull : ModItem
    {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			Tooltip.SetDefault("Summons a ghostly appiration");
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
		}
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 24;
			Item.value = 200;
			Item.rare = ItemRarityID.White;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.consumable = true;
			Item.noMelee = true;
			Item.autoReuse = false;
			Item.maxStack = 20;
		}
        public override bool CanUseItem(Player player)
        {
			return !NPC.AnyNPCs(ModContent.NPCType<Ghostboss>()) && player.ZoneGraveyard;
		}
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<GhostlyCloth>(), 3)
		
			.AddTile(TileID.Anvils)
			.Register();
			
		}
		public override bool? UseItem(Player player)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
            {
				NPC.NewNPC(Item.GetSource_ItemUse(Item), (int)player.position.X, (int)(player.position.Y - 50f),	ModContent.NPCType<Ghostboss>(), 0, 0f, 0f, 0f, 0f, 255);
				
				SoundEngine.PlaySound(SoundID.Roar, player.position);
				return true;
			}
			return false;
		}
	}
}
