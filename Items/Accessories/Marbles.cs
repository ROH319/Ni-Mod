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
    public class Marbles : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Pink, false,6);
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccMarbles>(out AccMarbles mplr);
            mplr.Marbles = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TatteredCloth, 5)
                .AddIngredient(ItemID.IchorBullet,50)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            base.AddRecipes();
        }
    }
}

