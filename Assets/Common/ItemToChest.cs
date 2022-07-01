
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using WorldsCollide.Items.Weapons.Melee;

namespace WorldsCollide.Assets.Common
{
	public class ItemToChest : ModSystem
    {
		public override void PostWorldGen()
		{
			int[] itemsToPlaceInLockedShadowChests = { ModContent.ItemType<MohgsTrident>()};
			int itemsToPlaceInLockedShadowChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 4 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							if (Main.rand.NextBool(7)) 
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInLockedShadowChests));
							}
							itemsToPlaceInLockedShadowChestsChoice = (itemsToPlaceInLockedShadowChestsChoice + 1) % itemsToPlaceInLockedShadowChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
						}
					}
				}
			}

			int[] itemsToPlaceInLockedGoldenChests = { ModContent.ItemType<Vendetta>() };
			int itemsToPlaceInLockedGoldenChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.None)
						{
							if (Main.rand.NextBool(4))
							{
								chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInLockedGoldenChests));
							}
							itemsToPlaceInLockedGoldenChestsChoice = (itemsToPlaceInLockedGoldenChestsChoice + 1) % itemsToPlaceInLockedGoldenChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
						}
					}
				}
			}
		}
    }
}
