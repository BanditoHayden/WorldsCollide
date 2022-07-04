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

namespace WorldsCollide.Assets.Common
{
    public class WorldsPlayer : ModPlayer
    {
        public bool Pickaxe = false;
        public bool StrengthMedallion;
        public bool Diplopia;
        public override void ResetEffects()
        {
            StrengthMedallion = false;
            Diplopia = false;
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (Helpers.Sets.IsAGreatsword[item.type])
            {
                if (StrengthMedallion)
                {
                    damage += 0.1f;

                }
            }
        }


    }
}
