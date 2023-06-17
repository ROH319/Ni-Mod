using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles;

namespace Ni.Items.Weapons
{/*
    public class Gwendolyn : BaseWeapon
    {
        public override void SetStaticDefaults()
        {
            //ItemID.Sets.Spears[Item.type] = true;
        }
        public override void SetDefaults()
        {
            QuickSDWe(50, 50, 40, DamageClass.Melee, 10, 10, 10, ItemUseStyleID.Thrust, false, 0.5f, ItemRarityID.Orange, false, false, true, true);
        }
        public override void HoldItem(Player player)
        {
            SpawnHeldProj(player, ModContent.ProjectileType<GwendolynProj>());
        }
        public override bool? UseItem(Player player)
        {
            return null;
        }
        

        public override bool AltFunctionUse(Player player)
        {
            
            Vector2 dashto = Main.MouseWorld - player.position;
            dashto.Normalize();
            player.velocity = dashto * 30;
            player.immuneTime = 10;
            return true;
        }
    }*/
}

