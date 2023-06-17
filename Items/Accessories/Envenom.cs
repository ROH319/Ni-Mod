using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.NiModPlayer;
using Ni.NiPrefix;
using Terraria.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Ni.Items.Accessories
{
    //public class Envenom : BaseAccessory
    //{
    //    public float damagereduced => Item?.prefix == ModContent.PrefixType<UpgradeCard>() ? 0f : 0.1f;
    //    public override void SetDefaults()
    //    {
    //        QuickSDAc(ItemRarityID.Pink, false);
    //        base.SetDefaults();
    //    }
    //    public override void UpdateAccessory(Player player, bool hideVisual)
    //    {
    //        NiPlayer niPlayer = player.GetModPlayer<NiPlayer>();
    //        niPlayer.Envenom = true;
    //        player.GetDamage(DamageClass.Generic) -= damagereduced;
    //        base.UpdateAccessory(player, hideVisual);
    //    }
    //    public override void AddRecipes()
    //    {
    //        CreateRecipe()
    //            .AddIngredient(ItemID.FlaskofVenom,5)
    //            .AddTile(TileID.MythrilAnvil)
    //            .Register();
    //    }

    //    public override int ChoosePrefix(UnifiedRandom rand)
    //    {
    //        Player player = Main.player[Main.myPlayer];
    //        player.TryGetModPlayer(out NiPlayer niPlayer);
    //        if (NPC.downedAncientCultist)
    //        {
    //            if (!niPlayer.Upgraded[1])
    //            {
    //                niPlayer.Upgraded[1] = true;
    //                return ModContent.PrefixType<UpgradeCard>();
    //            }
    //            else if (Main.rand.NextBool(10))
    //            {
    //                return ModContent.PrefixType<UpgradeCard>();
    //            }
    //        }
    //        return base.ChoosePrefix(rand);
    //    }

    //    public override void ModifyTooltips(List<TooltipLine> tooltips)
    //    {
    //        if (Item.prefix != ModContent.PrefixType<UpgradeCard>())
    //        {
    //            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
    //            if (line != null)
    //            {
    //                line.Text = Language.GetTextValue("Mods.Ni.ItemExtra.Envenom", 10) + "\n" + line.Text;
    //            }
    //        }
    //    }
    //}
}

