using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Items.Weapons;
using Terraria.DataStructures;
using System.Security.Cryptography.X509Certificates;
using Terraria.Audio;
using System.Collections.Generic;
using System.Linq;

namespace Ni.Items.Weapons
{
    public class ElectricWhip : BaseWeapon
    {
        public override void SetDefaults()
        {
            QuickSDWe(24, 24, 45, DamageClass.SummonMeleeSpeed, 0, 20, 20, ItemUseStyleID.Shoot, false, 5f, ItemRarityID.LightPurple, false, false, true, true,16);
            Item.shoot = ModContent.ProjectileType<ElecWhipProj>();
            Item.shootSpeed = 8f;
            Item.useTurn = true;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            for (int i = 0; i < 2; i++)
            {
                var p = Projectile.NewProjectileDirect(source, player.Center, Vector2.Zero, ModContent.ProjectileType<ElecWhipProj>(), damage, knockback, player.whoAmI, 500 * player.whipRangeMultiplier, -1);
            }
            return false;
        }
        public override bool MeleePrefix()
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MagnetSphere)
                .AddIngredient(ItemID.ThunderSpear)
                .AddIngredient(ItemID.Wire,20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
            if (line != null)
            {
                line.Text = Language.GetTextValue("Mods.Ni.ItemExtra.ElectricWhip",10) + "\n" + line.Text;
            }
        }
    }
}

