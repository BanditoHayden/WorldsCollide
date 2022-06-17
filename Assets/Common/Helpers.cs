using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using WorldsCollide.Items.Weapons.Melee;

namespace WorldsCollide
{
    public static class Helpers
    {
        public static WorldsPlayer GetWorldPlayer(this Player player) => player.GetModPlayer<WorldsPlayer>();
        public static class Sets
        {
            public static bool[] IsAGreatsword
            {
                get;
                private set;
            }
            public static void Initialize()
            {
                IsAGreatsword = new bool[ItemLoader.ItemCount];
                IsAGreatsword[ModContent.ItemType<GraveGreatsword>()] = true;
                IsAGreatsword[ModContent.ItemType<ChristmasClaymore>()] = true;
                IsAGreatsword[ModContent.ItemType<Pencil>()] = true;
                IsAGreatsword[ModContent.ItemType<OreClub>()] = true;
                IsAGreatsword[ModContent.ItemType<Vendetta>()] = true;
                IsAGreatsword[ModContent.ItemType<GracefulDahlia>()] = true;
                IsAGreatsword[ModContent.ItemType<StygianBlade>()] = true;
                IsAGreatsword[ModContent.ItemType<BigHammer>()] = true;
            }

        }
    }
}
