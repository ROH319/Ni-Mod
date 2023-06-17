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
    public class KillingDeck : BaseWeapon
    {
        public int Combo;
        public int Counter;
        public override void SetDefaults()
        {
            QuickSDWe(22, 24, 25, DamageClass.Ranged, 4, 20, 20, ItemUseStyleID.Shoot, false, 5f, ItemRarityID.Orange, false, false, true, false,4);
            Item.shoot = ModContent.ProjectileType<KillingDeckProj>();
            Item.shootSpeed = 7f;
            base.SetDefaults();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            Counter = 2 * 60;
            SoundEngine.PlaySound(AssetLoader.Card_Release[Combo], player.Center);
            
            switch (Combo)
            {
                case 0:
                    var p0 = Projectile.NewProjectileDirect(source, player.Center, tomouse * 8f, ModContent.ProjectileType<KillingDeckProj>(), damage, knockback, player.whoAmI);
                    //Main.NewText($"damage:{p0.damage}, oridamage:{p0.originalDamage},shootdamage:{damage}");
                    break;
                case 1:
                    for (int i = 0; i < 2; i++)
                    {
                        var p1 = Projectile.NewProjectileDirect(source, player.Center, (i == 0) ? tomouse * 8f : tomouse * -10f, ModContent.ProjectileType<KillingDeckProj>(), damage, knockback, player.whoAmI);
                    }
                    break;
                case 2:
                    for(int k = -3; k < 4; k++)
                    {
                        var p2 = Projectile.NewProjectileDirect(source, player.Center, tomouse.RotatedBy(k * Math.PI/36) * 8f, ModContent.ProjectileType<KillingDeckProj>(), damage, knockback, player.whoAmI);
                    }
                    break;
                case 3:
                    foreach(Projectile p in Main.projectile)
                    {
                        if (p.type == ModContent.ProjectileType<KillingDeckProj>())
                        {
                            p.ai[0] = 1;
                        }
                    }
                    break;
                default:
                    //Main.NewText("default");
                    break;
            }
            Combo++;
            if(Combo > 3)
            {
                Combo = 0;
            }
            return false;
        }
        public override void HoldItem(Player player)
        {
            if(Counter > 0)
            {
                Counter--;
            }
            if (Counter == 0)
            {
                Combo = 0;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Book,2)
                .AddRecipeGroup("EvilBossMaterial",5)
                .AddIngredient(ItemID.Bone,5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

