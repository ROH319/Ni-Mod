using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using Ni.Projectiles;
using Terraria.Audio;

namespace Ni.Items.Weapons
{
    public class WarJavelin : BaseWeapon
    {
        public override void SetDefaults()
        {
            QuickSDWe(24, 24, 200, DamageClass.Ranged, 10, 10, 10, ItemUseStyleID.Shoot, false, 1f, ItemRarityID.LightRed, false, false, true, false,20);
            Item.shoot = ModContent.ProjectileType<WarJavelinProj>();
            Item.shootSpeed = 7f;
            Item.noUseGraphic = true;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //SoundEngine.PlaySound(AssetLoader.WarJavelin_Use, player.Center);
            
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<WarJavelinProj>()] < 1)
            {
                Projectile proj = Projectile.NewProjectileDirect(source, player.Center, tomouse*18, type, damage, knockback, player.whoAmI);
                return false;
            }
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<WarJavelinProj>()] > 0)
            {
                return true;
            }
            return false;
        }

    }
}

