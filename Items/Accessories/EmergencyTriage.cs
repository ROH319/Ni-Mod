using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;
using Ni.Items.AccEffects;

namespace Ni.Items.Accessories
{
    public class EmergencyTriage : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Pink, false,8);
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccEmergencyTriage>(out AccEmergencyTriage mt);
            mt.EmergencyTriage = true;
            #region ¼õCDÐ§¹û
            player.potionDelayTime = (int)(player.potionDelayTime * 0.5);
            player.restorationDelayTime = (int)(player.restorationDelayTime * 0.5);
            player.mushroomDelayTime = (int)(player.mushroomDelayTime * 0.5);
            #endregion
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GreaterHealingPotion, 5)
                .AddIngredient(ItemID.FastClock)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

