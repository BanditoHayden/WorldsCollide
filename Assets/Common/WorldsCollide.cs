using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace WorldsCollide.Assets.Common
{
	public class WorldsCollide : Mod
	{
        public override void Load()
        {
            Helpers.Sets.Initialize();
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> screenRef = new Ref<Effect>(ModContent.Request<Effect>("WorldsCollide/Assets/Effects/ShockwaveEffect", AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["Shockwave"].Load();
            }
        }
	 public static RecipeGroup Fishes;
        public override void AddRecipeGroups()
        {
            // Create a recipe group and store it
            // Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
            Fishes = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Fish)}",
                ItemID.Bass, ItemID.CrimsonTigerfish,ItemID.Damselfish, ItemID.DoubleCod, ItemID.Ebonkoi, ItemID.Flounder, ItemID.GoldenCarp, ItemID.Hemopiranha, ItemID.Honeyfin, ItemID.NeonTetra, ItemID.RedSnapper, ItemID.Salmon, ItemID.Shrimp, ItemID.Trout, ItemID.Tuna);
            RecipeGroup.RegisterGroup("WorldsCollide:Fishes", Fishes);
        }
    	public override void AddRecipes()
        {
            CreateRecipe(ItemID.SlimeStaff, 1)
            .AddIngredient(ModContent.ItemType<SlimeDust>(), 50)
            .AddRecipeGroup(RecipeGroupID.Wood, 12)
            .AddTile(TileID.WorkBenches)
            .Register();
	    
	    CreateRecipe(ModContent.ItemType<Chum>(), 3)
           .AddRecipeGroup("WorldsCollide:Fishes", 1)
           .AddTile(TileID.Extractinator)
           .Register();
        }  
    }
}
