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
using Ni.NiPrefix;
using Terraria.Utilities;
using System.Collections.Generic;
using System.Linq;
using Ni.Projectiles;

namespace Ni.Items.Accessories
{
    //public class FlameBarrier : BaseAccessory
    //{
    //    public override void SetDefaults()
    //    {
    //        QuickSDAc(ItemRarityID.LightRed, false);
    //        base.SetDefaults();
    //    }

    //    public override void UpdateAccessory(Player player, bool hideVisual)
    //    {
    //        player.TryGetModPlayer(out NiPlayer niPlayer);
    //        niPlayer.FlameBarrier = true;
    //        if (player.ownedProjectileCounts[ModContent.ProjectileType<FlameLogicProj>()] < 1 && !player.HasBuff(ModContent.BuffType<FlameCooldownDebuff>()))
    //        {
    //            var p = Projectile.NewProjectileDirect(player.GetSource_Accessory(this.Item), player.Center, Vector2.Zero, ModContent.ProjectileType<FlameLogicProj>(), 0, 0f, player.whoAmI, Item.Upgraded() ? 400 : 300);
    //        }
    //    }

    //    public override void AddRecipes()
    //    {
    //        CreateRecipe()
    //            .AddIngredient(ItemID.MagmaStone)
    //            .AddIngredient(ItemID.InfernoPotion)
    //            .AddIngredient(ItemID.SoulofNight,8)
    //            .AddTile(TileID.MythrilAnvil)
    //            .Register();
    //    }
    //    public override int ChoosePrefix(UnifiedRandom rand)
    //    {
    //        Player player = Main.player[Main.myPlayer];
    //        player.TryGetModPlayer(out NiPlayer niPlayer);
    //        if (NPC.downedAncientCultist)
    //        {
    //            if (!niPlayer.Upgraded[0])
    //            {
    //                niPlayer.Upgraded[0] = true;
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
    //        TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
    //        if (line != null)
    //        {
    //            line.Text = Language.GetTextValue("Mods.Ni.ItemExtra.FlameBarrier", Item.Upgraded() ? "" : 300, Item.Upgraded() ? 400 : " ") + "\n" + line.Text;
    //        }
    //        base.ModifyTooltips(tooltips);
    //    }
    //}
}

