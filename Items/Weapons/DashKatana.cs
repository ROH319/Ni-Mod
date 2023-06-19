using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.Projectiles;
using Ni.Core;
using Ni.Helpers;

namespace Ni.Items.Weapons
{
    public class DashKatana : BaseWeapon
    {
        public override void SetDefaults()
        {
            QuickSDWe(10, 33, 140, DamageClass.Melee, 4, 10, 10, ItemUseStyleID.None, true, 5f, ItemRarityID.Pink, false, false, true,false,16);
            Item.shoot = ModContent.ProjectileType<KatanaProj>();
            Item.shootSpeed = 1f;
            base.SetDefaults();
        }
        public override void HoldItem(Player player)
        {
            SpawnHeldProj(player, ModContent.ProjectileType<KatanaProj>());
            base.HoldItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Muramasa)
                .AddIngredient(ItemID.Katana)
                .AddIngredient(ItemID.Ectoplasm, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            base.AddRecipes();
        }
    }

    public class KatanaDashPlayer : ModPlayer
    {
        public Vector2 dashvel;
        public int dashduration = 10;
        public int dashdelay = 20;
        public int dashtimer;
        public override void PreUpdateMovement()
        {
            float progress = dashtimer < 4 ? 1 - (dashtimer * 3) / 10f : 1;
            if (CanKatanaDash(Player))
            {
                dashvel = (Main.MouseWorld - Player.Center).NormalizeV() * 40;

                Player.dashDelay = dashdelay;
                dashtimer = dashduration;
            }
            if(dashtimer > 0)
            {
                Player.velocity = dashvel * progress;
                dashtimer--;
            }
            base.PreUpdateMovement();
        }

        public static bool CanKatanaDash(Player player)
        {
            return player.altFunctionUse == 1 && player.dashDelay == 0 && player.HeldItem.type == ModContent.ItemType<DashKatana>();
        } 
    }
}

