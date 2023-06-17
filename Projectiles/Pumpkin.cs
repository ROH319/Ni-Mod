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
            // ���Ѱ�о���Ϊ1000����
            float distanceMax = 1400f;
            foreach (NPC npc in Main.npc)
            {
                // ���npc�����ҵж�������ֵ������
                if (!npc.active || npc.friendly || npc.lifeMax <= 5) continue;
                // ��������ҵľ��룬���Ըĳ��뵯Ļ�ľ���
                float currentDistance = Vector2.Distance(npc.Center, Projectile.Center);
                // ���npc����ȵ�ǰ������С
                if (currentDistance < distanceMax)
                {
                    // �Ͱ�����������Ϊnpc����ҵľ���
                    // ������ʱѡȡ���npcΪ�������npc
                    distanceMax = currentDistance;
                    target = npc;
                }

            }
            // ����ҵ�����������npc
            if (target != null)
            {
                Projectile.velocity = Vector2.Lerp(target.Center, Projectile.Center, Vector2.Distance(target.Center, Projectile.Center));
                // ���ɧ����д������
            }


        }
        
    }
}

