using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class arzunaProj: BaseRotateProj
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 3; 
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            QuickSD(16, 3, 40, DamageClass.Ranged, 6f, true, false, 1, 0, -1, 1f, 10 * 60, false, false, true, true, true, 20);
        }
        public override void OnSpawn(IEntitySource source)
        {
            if(ai0 == 0)
            {
                Projectile.extraUpdates = 5;
                Projectile.penetrate = -1;
            }
            else
            {
                //Main.NewText($"{Projectile.CritChance} {player.GetCritChance(DamageClass.Ranged)}");
                Projectile.CritChance = 100;
                orirot = ToMouse.ToRotation();
                oriVec = ToMouse;
                oriVec.Normalize();
            }
            base.OnSpawn(source);
        }
        NPC target = null;
        float orirot = 0f;
        Vector2 oriVec = Vector2.Zero;
        int accCheck = 0;
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            //追踪弹
            if (ai0 == 1)
            {
                ProjectileID.Sets.CultistIsResistantTo[Type] = true;
                Projectile.CritChance = 4;
                //Main.NewText($"{Projectile.CritChance} {player.GetCritChance(DamageClass.Ranged)}");
                if (accCheck < 80)
                {
                    Projectile.velocity += oriVec;
                    accCheck++;
                }
                target = Projectile.FindTargetWithinRange(1000f, true);
                if(target != null)
                {
                    // 目标速度
                    var targetVel = Vector2.Normalize(target.Center - Projectile.Center) * 20f;
                    // 加权平均 1份目标速度和10份当前速度
                    Projectile.velocity = (targetVel * 3 + Projectile.velocity * 8) / 11f;
                }
            }
            else
            {
                if (Main.time % 1 == 0)
                {
                    Dust d = Dust.NewDustPerfect(Projectile.Center, MyDustId.TrailingBlue);
                    d.scale /= 4;
                    //d.scale *= 2;
                    d.velocity = Vector2.Zero;
                    d.noGravity = true;
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D tex = AssetHelper.GetTex(Texture);
            sb.AdditiveBegin();
            sb.Draw(tex, Projectile.position - Main.screenPosition, null, Color.White, Projectile.rotation, tex.Size() / 2, Projectile.scale, 0, 0);
            sb.VanillaBegin();
            return false;
        }


    }
}

