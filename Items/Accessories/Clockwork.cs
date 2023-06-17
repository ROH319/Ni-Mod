using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiModPlayer;
using Ni.Buffs;

namespace Ni.Items.Accessories
{
    public class Clockwork : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.LightRed, false,8);
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<NiPlayer>(out NiPlayer niplayer);
            if (!player.HasBuff<ClockworkCooldown>())
            {
                niplayer.Artifact = true;

            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cog, 10)//10¸ö³ÝÂÖ
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}

