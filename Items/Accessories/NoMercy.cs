using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiModPlayer;
using Ni.Items.AccEffects;

namespace Ni.Items.Accessories
{
    public class NoMercy : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.LightPurple, false,9);
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccNoMercy>(out AccNoMercy nm);
            nm.NoMercy = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DeathSickle)
                .AddIngredient(ItemID.SoulofNight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

