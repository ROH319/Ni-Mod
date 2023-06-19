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
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.Audio;
using Ni.Helpers;

namespace Ni.Items.Weapons
{
    public class arzuna : BaseWeapon
    {
        public override void SetDefaults()
        {
            QuickSDWe(16, 25, 85, DamageClass.Ranged, 0, 8, 8, ItemUseStyleID.Shoot, false, 6f, ItemRarityID.LightRed, false, false, true, false,16);
            Item.shoot = ModContent.ProjectileType<arzunaProj>();
            Item.shootSpeed = 5f;
            base.SetDefaults();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            Projectile p = Projectile.NewProjectileDirect(source, player.Center, tomouse * 10, ModContent.ProjectileType<arzunaProj>(), damage, knockback, player.whoAmI);
            SoundEngine.PlaySound(AssetHelper.LaserBow_Use, player.Center);
            return false;
        }

        public override void HoldItem(Player player)
        {
            if (player.dashDelay == -1 && Main.time % 2 == 0)
            {
                Vector2 tomouse = Main.MouseWorld - player.Center;
                tomouse.Normalize();
                Projectile p = Projectile.NewProjectileDirect(player.GetSource_FromThis(), player.Center, new Vector2(-tomouse.X, -tomouse.Y) * 15, ModContent.ProjectileType<arzunaProj>(), (int)player.GetTotalDamage(DamageClass.Ranged).ApplyTo(Item.damage) * 1, Item.knockBack, player.whoAmI, 1);
                p.CritChance = Item.crit;
                //Main.NewText($"{p.CritChance} {Item.crit} {player.GetCritChance(DamageClass.Ranged)}");
                SoundEngine.PlaySound(AssetHelper.LaserBow_Extra, player.Center);            
            }
            base.HoldItem(player);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PulseBow)
                .AddIngredient(ItemID.Ectoplasm, 8)
                .AddTile(TileID.MythrilAnvil)
                .Register();
            base.AddRecipes();
        }
    }
}

