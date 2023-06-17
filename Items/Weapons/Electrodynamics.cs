using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles.Minions;
using Terraria.DataStructures;
using Ni.Buffs;
using Terraria.Audio;
using Terraria.Utilities;
using Ni.NiModPlayer;
using Ni.NiPrefix;
using System.Collections.Generic;
using System.Linq;
using Ni.Items.AccEffects;

namespace Ni.Items.Weapons
{
    public class Electrodynamics : BaseWeapon
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            QuickSDWe(19, 24, 85, DamageClass.Summon, 0, 20,20,ItemUseStyleID.Swing, false, 2f, ItemRarityID.LightPurple, false, false, true, false,20);
            Item.shoot = ModContent.ProjectileType<LightningOrb>();
            Item.shootSpeed = 10f;
            Item.mana = 10;
            Item.buffType = ModContent.BuffType<LightningBuff>();
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            SoundEngine.PlaySound(AssetLoader.LightningOrb_Channel,player.Center);
            player.GetModPlayer<NiPlayer>().OwnedMinions.RemoveAll(x => !x.active);
            int order = player.GetModPlayer<NiPlayer>().OwnedMinions.Count(x => x.type == type);
            
            player.AddBuff(Item.buffType, 1145);
            var min = Projectile.NewProjectileDirect(source, player.Center, Vector2.Zero, ModContent.ProjectileType<LightningOrb>(), damage, knockback, player.whoAmI, order + 1);
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MagnetSphere)
                .AddIngredient(ItemID.ThunderStaff)
                .AddIngredient(ItemID.Ectoplasm, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        public override int ChoosePrefix(UnifiedRandom rand)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            if (NPC.downedAncientCultist)
            {
                if (!CardPlayer.Upgraded[2])
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
                line.Text += "\n" + Language.GetTextValue("Mods.Ni.ItemExtra.Electrodynamics", Item.Upgraded() ? "" : 50, Item.Upgraded() ? 100 : "");
            }
            base.ModifyTooltips(tooltips);
        }
    }
}

