using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Ni.Items.Weapons;
using Terraria.Social.Steam;

namespace Ni.Projectiles
{/*
    public class GwendolynProj : BaseHeldProj
    {
        public override int Weapon => ModContent.ItemType<Gwendolyn>();
        public override void SetDefaults()
        {
            //QuickSD(71, 16, 40, DamageClass.Melee, 0.5f, true, false, -1, 0, -1, 1.1f, 1145141919, false, false, false, true, true,40);
            QuickSDHELD2(71, 16, 40, DamageClass.Melee, 0.5f, 0);
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }
        bool onuseitem = false;
        bool dash = false;
        Vector2 preDashpos = new Vector2(0);
        Vector2 dashTo = new Vector2(0);
        public override void AI()
        {
            //Projectile.ai[0]++;
            var duration = player.itemAnimationMax;
            var itemAnimation = player.itemAnimation;
            float factor = (float)player.itemAnimation/player.itemAnimationMax;
            var r = 20;
            Projectile.rotation = ToMouse.ToRotation();
            if(player.altFunctionUse == 2 && !dash)
            {
                
                Vector2 tomouse = Main.MouseWorld - player.Center;
                tomouse.Normalize();
                preDashpos = player.Center;
                dashTo = player.Center + tomouse * 250;
                dash = true;
            }
            if (dash)
            {
                player.Center = Vector2.Lerp(dashTo, preDashpos, factor);
                if (factor < 0.1 )
                {
                    dash = false;
                }
            }
            switch (ai0)
            {
                case 0:
                    {
                        player.SetCompositeArmFront(true, 0, Projectile.rotation - MathHelper.PiOver2);
                        Projectile.Center = player.Center;
                        Projectile.velocity = (Main.MouseWorld - player.Center) * 0.001f;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }*/
}

