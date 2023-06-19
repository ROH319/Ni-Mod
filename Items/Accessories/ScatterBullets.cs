using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Ni.Core;
using Ni.Items.AccEffects;

namespace Ni.Items.Accessories
{
    public class ScatterBullets:BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.LightPurple, false,10);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer(out AccScatterBullets sb);
            sb.ScatterBullets = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IllegalGunParts)
                .AddIngredient(ItemID.EmptyBullet, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

