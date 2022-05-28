﻿using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WorldsCollide
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
                        int possibleitems = Main.rand.Next(new int[] { 11, 12, 13, 14, 699, 700, 701, 702, 999, 182, 178, 179, 177, 180, 181 });
                        Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, possibleitems);
                    }
                }
            }
        }
    }
}
