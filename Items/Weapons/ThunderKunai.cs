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
using Terraria.Audio;

namespace Ni.Items.Weapons
{
    //public class ThunderKunai : BaseWeapon
    //{
    //    public override void SetDefaults()
    //    {
    //        QuickSDWe(14, 28, 10, DamageClass.Ranged, 4, 8, 8, ItemUseStyleID.Swing, false, 4f, ItemRarityID.Blue, false, false, true, true);
    //        Item.shoot = ModContent.ProjectileType<ThunderKunaiProj>();
    //        Item.shootSpeed = 2f;
    //        Item.reuseDelay = 8;
    //        base.SetDefaults();
    //    }

    //    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    //    {
    //        Vector2 tomouse = Main.MouseWorld - player.Center;
    //        tomouse.Normalize();
    //        Projectile p = Projectile.NewProjectileDirect(source, player.Center, tomouse * 4, type, Item.damage, knockback, player.whoAmI);
    //        SoundEngine.PlaySound(AssetHelper.KunaiShoot, player.Center);
    //        return false;
    //    }
    //    public override void AddRecipes()
    //    {
    //        CreateRecipe()
    //            .AddIngredient(ItemID.SilverBar, 6)
    //            .AddTile(TileID.Anvils)
    //            .Register();
    //    }
    //}
}

