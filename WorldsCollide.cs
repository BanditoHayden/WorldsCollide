using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using WorldsCollide.Assets.Common;

namespace WorldsCollide
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
    }
}
