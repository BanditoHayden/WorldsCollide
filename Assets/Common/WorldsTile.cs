using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide.Assets.Common
{
    public class WorldsTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!Main.dedServ)
            {
                Player player = Main.LocalPlayer;
                WorldsPlayer modPlayer = player.GetWorldPlayer();
                if (type == TileID.Stone || type == 25 || type == 117 || type == 203 || type == 57)
                {
                    if (Main.rand.NextBool(20)&& modPlayer.Pickaxe && !fail)
                    {
                        int possibleitems = Main.rand.Next(new int[] { 177, 178, 179, 180, 181, 182 });
                        Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, possibleitems);
                    }
                }
            }
        }
       public override bool Drop(int i, int j, int type)
        {
		Player player = Main.LocalPlayer;
		WorldsPlayer modPlayer = player.GetWorldPlayer();
		if (TileID.Sets.Ore[type] && modPlayer.Diplopia)
        	 	{
			 DropTheGoods(i, j, type);
			}
			return true;
		}
		public void DropTheGoods(int i, int j, int type)
		{
			ModTile modTile = TileLoader.GetTile(type);
			if (modTile == null)
			{
				if (TileID.Sets.Ore[type] && WorldsCollide.oreTileToItem.TryGetValue(type, out int item))
				{
				  Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, item, Stack: 1);
				}
			}
			else
			{
				if (TileID.Sets.Ore[type])
				{
					int drop = modTile.ItemDrop;
					if (drop > 0)
					{
					  Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, drop, 1);
					}
				}
			}

		}
    }	
}
