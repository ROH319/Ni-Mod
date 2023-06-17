using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;

namespace Ni.Projectiles
{
    public class Pumpkin : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 32;
            Projectile.frame = 3;
            Projectile.damage = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 114514;
            Projectile.penetrate = 1;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.tileCollide = true;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;
        }
        

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.frameCounter++;
            if(Projectile.frameCounter > 2)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if(Projectile.frame > 2)
                {
                    Projectile.frame = 0;
                }
            }
            NPC target = null;
            // 最大寻敌距离为1000像素
            float distanceMax = 1400f;
            foreach (NPC npc in Main.npc)
            {
                // 如果npc活着且敌对且生命值大于五
                if (!npc.active || npc.friendly || npc.lifeMax <= 5) continue;
                // 计算与玩家的距离，可以改成与弹幕的距离
                float currentDistance = Vector2.Distance(npc.Center, Projectile.Center);
                // 如果npc距离比当前最大距离小
                if (currentDistance < distanceMax)
                {
                    // 就把最大距离设置为npc和玩家的距离
                    // 并且暂时选取这个npc为距离最近npc
                    distanceMax = currentDistance;
                    target = npc;
                }

            }
            // 如果找到符合条件的npc
            if (target != null)
            {
                Projectile.velocity = Vector2.Lerp(target.Center, Projectile.Center, Vector2.Distance(target.Center, Projectile.Center));
                // 你的骚操作写在这里
            }


        }
        
    }
}

