using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using WorldsCollide.Items.Materials;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.GameContent;

namespace WorldsCollide.Assets.Common
{
    public class WorldsCollide : Mod
    {
        private Asset<Texture2D> oldTexture;
        public static Dictionary<int, int> oreTileToItem;
        public static Dictionary<int, int> oreItemToTile;
        public override void Load()
        {
            Helpers.Sets.Initialize();
            PickaxeNerf.Sets.Initialize();
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> screenRef = new Ref<Effect>(ModContent.Request<Effect>("WorldsCollide/Assets/Effects/ShockwaveEffect", AssetRequestMode.ImmediateLoad).Value);
                Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["Shockwave"].Load();
            }
            oreTileToItem = new Dictionary<int, int>();
            oreItemToTile = new Dictionary<int, int>();
            oldTexture = TextureAssets.Item[ItemID.BladeofGrass];
            TextureAssets.Item[ItemID.BladeofGrass] = ModContent.Request<Texture2D>("WorldsCollide/Assets/Vanilla/BladeofGrass2");
            BaseIdleHoldoutProjectile.LoadAll();
        }

        public override void Unload()
        {
            oreTileToItem = null;
            oreItemToTile = null;
            TextureAssets.Item[ItemID.BladeofGrass] = oldTexture;
        }
        public override void PostSetupContent()
        {
            for (int item = 0; item < ItemLoader.ItemCount; item++)
            {
                Item test = new Item();
                test.SetDefaults(item);
                int tile = test.createTile;
                if (tile > -1 && tile < TileLoader.TileCount && TileID.Sets.Ore[tile])
                {
                    if (!oreTileToItem.ContainsKey(tile))
                    {
                        oreTileToItem.Add(tile, item);
                    }

                    if (!oreItemToTile.ContainsKey(item))
                    {
                        oreItemToTile.Add(item, tile);
                    }
                }
            }
        }
        public static RecipeGroup Fishes;
        public override void AddRecipeGroups()
        {
            // Create a recipe group and store it
            // Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
            Fishes = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.Fish)}",
                ItemID.Bass, ItemID.CrimsonTigerfish, ItemID.Damselfish, ItemID.DoubleCod, ItemID.Ebonkoi, ItemID.Flounder, ItemID.GoldenCarp, ItemID.Hemopiranha, ItemID.Honeyfin, ItemID.NeonTetra, ItemID.RedSnapper, ItemID.Salmon, ItemID.Shrimp, ItemID.Trout, ItemID.Tuna);
            RecipeGroup.RegisterGroup("WorldsCollide:Fishes", Fishes);
        }
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<Chum>())
           .AddRecipeGroup("WorldsCollide:Fishes", 1)
           .AddTile(TileID.Extractinator)
           .Register();

            Recipe.Create(ItemID.HighTestFishingLine)
            .AddIngredient(ModContent.ItemType<Chum>(), 30)
            .AddIngredient(ItemID.Cobweb, 20)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();

            Recipe.Create(ItemID.TackleBox)
           .AddIngredient(ModContent.ItemType<Chum>(), 30)
           .AddIngredient(ItemID.Wood, 20)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

            Recipe.Create(ItemID.AnglerEarring)
            .AddIngredient(ModContent.ItemType<Chum>(), 30)
            .AddRecipeGroup(RecipeGroupID.IronBar, 12)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();

            Recipe.Create(ItemID.FishermansGuide)
           .AddIngredient(ModContent.ItemType<Chum>(), 30)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

            Recipe.Create(ItemID.Sextant)
           .AddIngredient(ModContent.ItemType<Chum>(), 30)
           .AddRecipeGroup(RecipeGroupID.IronBar, 12)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

            Recipe.Create(ItemID.WeatherRadio)
           .AddIngredient(ModContent.ItemType<Chum>(), 30)
           .AddRecipeGroup(RecipeGroupID.IronBar, 12)
           .AddTile(TileID.TinkerersWorkbench)
           .Register();

            Recipe.Create(ItemID.LavaFishingHook)
            .AddIngredient(ModContent.ItemType<Chum>(), 30)
            .AddIngredient(ItemID.Obsidian, 30)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}