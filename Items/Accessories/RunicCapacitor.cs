using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Items.Accessories
{
    public class RunicCapacitor : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Cyan, false,16);
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxMinions += 3;
            base.UpdateAccessory(player, hideVisual);
        }
        public override void AddRecipes()
        {
            //CreateRecipe()
            //    .AddIngredient(ItemID.LihzahrdPowerCell)
            //    .AddTile(TileID.LunarCraftingStation)
            //    .Register();
        }
    }
}

