using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;
using Ni.NiPrefix;
using Terraria.Utilities;
using System.Collections.Generic;
using System.Linq;
using Ni.Items.AccEffects;
using Ni.Helpers;

namespace Ni.Items.Accessories
{
    public class Barricade : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Yellow, false,9);
            Item.defense = 6;
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            player.TryGetModPlayer<NiPlayer>(out NiPlayer niplayer);
            player.statLifeMax2 += (int)(player.statDefense * (Item.Upgraded() ? 1.5 : 1));
            niplayer.Barricade = true;
            if (Item.Upgraded())
            {
                CardPlayer.HasUpgradedItem[0] = true;
            }
            base.UpdateAccessory(player, hideVisual);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ObsidianShield)
                .AddIngredient(ItemID.FleshKnuckles)
                .AddIngredient(ItemID.PaladinsShield)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            base.AddRecipes();
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            if (NPC.downedAncientCultist)
            {
                if (!CardPlayer.Upgraded[0])
                {
                    return ModContent.PrefixType<UpgradeCard>();
                }
                else if (Main.rand.NextBool(10))
                {
                    return ModContent.PrefixType<UpgradeCard>();
                }
            }
            return base.ChoosePrefix(rand);
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
            if (line != null)
            {
                line.Text = line.Text + "\n" + Language.GetTextValue($"Mods.Ni.ItemExtra.Barricade{(Item.Upgraded() ? 2 : 1)}");
            }

        }
    }
}

