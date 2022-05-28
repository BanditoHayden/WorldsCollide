using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace WorldsCollide
{
    public class WorldsPlayer : ModPlayer
    {
        public bool Pickaxe = false;
        private void ResetItems()
        {
            Pickaxe = false; 
        }

    }
}
