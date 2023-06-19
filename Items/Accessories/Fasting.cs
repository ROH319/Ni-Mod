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
    public class Fasting : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.LightRed, false,10);
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 -= 60;
            player.GetDamage(DamageClass.Magic) += Item.Upgraded() ? 0.3f : 0.2f;
            player.statDefense += Item.Upgraded() ? 15 : 10;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SuperManaPotion, 10)
                .AddIngredient(ItemID.SoulofLight, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            Player player = Main.player[Main.myPlayer];
            if (NPC.downedAncientCultist)
            {
                if (!CardPlayer.Upgraded[3])
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
                line.Text += "\n" + Language.GetTextValue("Mods.Ni.ItemExtra.Fasting1", Item.Upgraded() ? "" : 20, Item.Upgraded() ? 30 : "");
                line.Text += "\n" + Language.GetTextValue("Mods.Ni.ItemExtra.Fasting2", Item.Upgraded() ? "" : 10, Item.Upgraded() ? 15 : "");
            }
            base.ModifyTooltips(tooltips);
        }
    }
}

