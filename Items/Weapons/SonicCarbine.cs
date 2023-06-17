using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.NiGlobalProj;

namespace Ni.Items.Weapons
{/*
    public class SonicCarbine : BaseWeapon
    {
        public override void SetDefaults()
        {
            QuickSDWe(24, 24, 40, DamageClass.Ranged, 4, 2, 2, ItemUseStyleID.Shoot, false, 5f, ItemRarityID.Yellow, false, false, true, false);
            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 16f;
            Item.staff[Type] = true;
            Item.autoReuse = true;
            Item.useTurn = true;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.MoonlordArrow;
            }
            //Main.NewText($"{type}");
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            Projectile p = Projectile.NewProjectileDirect(source, player.Center, velocity * 7, type, damage, knockback, player.whoAmI);
            p.penetrate = -1;
            NiGProj niGProj = p.GetGlobalProjectile<NiGProj>();
            niGProj.Carbine = true;
            return false;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }*/
}

