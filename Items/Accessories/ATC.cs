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
using Terraria.Server;
using Terraria.GameContent.ItemDropRules;
using Ni.Items.AccEffects;
using Ni.Helpers;

namespace Ni.Items.Accessories
{
    public class ATC : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Pink, false,10);
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccATC>(out AccATC atc);
            atc.ATCEnabled = true;
            if (Item.Upgraded())
            {
                CardPlayer.HasUpgradedItem[1] = true;
            }
            base.UpdateAccessory(player, hideVisual);
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            if (NPC.downedAncientCultist)
            {
                if (!CardPlayer.Upgraded[1])
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
                line.Text = line.Text + Language.GetTextValue("Mods.Ni.ItemExtra.ATC", Item.Upgraded() ? "" : 4, Item.Upgraded() ? 8 : "");
            }
            
        }
    }
    public class ATCDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                NPC npc = info.npc;
                if (npc.boss || NPCID.Sets.CannotDropSouls[npc.type])
                {
                    return false;
                }
                if (!NPC.downedPlantBoss || npc.lifeMax <= 1 || npc.friendly)
                {
                    return false;
                }

                return info.player.ZoneDungeon;
            }
            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "»¨ºóµØÀÎµôÂä";
        }
    }
}

