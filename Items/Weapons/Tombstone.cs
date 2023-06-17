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

namespace Ni.Items.Weapons
{/*
    public class Tombstone : BaseWeapon
    {

        public int Combo;
        public int Counter;
        public override void SetDefaults()
        {
            QuickSDWe(22, 24, 40, DamageClass.Melee, 10, 12, 12, ItemUseStyleID.Shoot, false, 7f, ItemRarityID.Green, false, false, true, true);
            Item.shoot = ModContent.ProjectileType<TombstoneProj>();
            Item.shootSpeed = 5f;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            Projectile p = Projectile.NewProjectileDirect(source, position, Vector2.Zero, ModContent.ProjectileType<TombstoneProj>(), damage, knockback, player.whoAmI, Combo);
            p.localAI[0] = tomouse.X;
            p.localAI[1] = tomouse.Y;
            Counter = 2 * 60;
            Combo++;
            if (Combo > 2)
            {
                Combo = 0;
            }
            return false;
        }
        public override void HoldItem(Player player)
        {
            //Main.NewText($"{Combo} {Counter}");
            if (Counter > 0)
            {
                Counter -= 2;
            }
            if (Counter == 0)
            {
                Combo = 0;
            }
            base.HoldItem(player);
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }*/
}

