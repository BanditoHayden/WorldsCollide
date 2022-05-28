using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria;
using Terraria.Audio;
using WorldsCollide.Npcs.Bosses;

namespace WorldsCollide.Items.Consumables
{
    public class GhostlySkull : ModItem
    {
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			Tooltip.SetDefault("Summons a ghostly appiration");
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
			return !NPC.AnyNPCs(NPCID.Ghost) && player.ZoneGraveyard;
		}
        public override bool? UseItem(Player player)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
            {
				NPC.NewNPC(Item.GetSource_ItemUse(Item), (int)player.position.X, (int)(player.position.Y - 50f), NPCID.Ghost, 0, 0f, 0f, 0f, 0f, 255);
				SoundEngine.PlaySound(SoundID.Roar, player.position, 0);
				return true;
			}
			return false;
		}
	}
}
