using rail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles;
using Terraria.DataStructures;

namespace Ni.Items.Weapons
{
    /*
    public class Hecate:BaseWeapon
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            Item.useTurn = false;
            Item.useAmmo = AmmoID.Bullet;
            QuickSDWe(64, 24, 100, DamageClass.Ranged, 24, 30, 30, ItemUseStyleID.Shoot, false, 1f, ItemRarityID.Purple, false, false, true, true);
            Item.shoot = ModContent.ProjectileType<HecateBullet>();
            Item.shootSpeed = 14;
        }
        public override void HoldItem(Player player)
        {
            SpawnHeldProj(player, ModContent.ProjectileType<HecateProj>());
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 tomouse = Main.MouseWorld - player.Center;
            tomouse.Normalize();
            Projectile p = Projectile.NewProjectileDirect(source, player.Center, tomouse * 6f, ModContent.ProjectileType<HecateBullet>(), damage, knockback, player.whoAmI);
            return false;
        }

        public static void DrawLine(SpriteBatch sb, GraphicsDevice gd,Texture2D tex, PrimitiveType primitiveType, List<VertexInfo2> triangleList)
        {
            sb.End();
            sb.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            gd.Textures[0] = tex;
            gd.DrawUserPrimitives(primitiveType, triangleList.ToArray(), 0, triangleList.Count / 3);
            sb.End();
            sb.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SniperRifle)
                .AddIngredient(ItemID.SoulofNight,10)
                .AddIngredient(ItemID.FragmentVortex,10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }*/
}
