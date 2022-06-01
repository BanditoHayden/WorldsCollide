using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Utilities;

namespace WorldsCollide
{
    public static class Helpers
    {
        public static WorldsPlayer GetWorldPlayer(this Player player) => player.GetModPlayer<WorldsPlayer>();
    }
}
