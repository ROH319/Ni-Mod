using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using log4net.Appender;

namespace Ni.Items.Accessories
{
    public class HolyWater : BaseAccessory
    {
        public static int ManaIncreaseBy = 60;
        public static int ManaReduceBy = 25;
        //public new LocalizedText Tooltip;
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.LightRed, false,9);
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 60;
            if (player.statMana > player.statManaMax2 / 2)
            {
                player.manaCost *= 0.75f;
            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HolyWater)
                .AddIngredient(ItemID.ManaPotion)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

