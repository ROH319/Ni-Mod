using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;

namespace Ni.Projectiles
{
    public abstract class BaseProj : ModProjectile
    {
        public SpriteBatch sb => Main.spriteBatch;
        public Player player => Main.player[Projectile.owner];

        public NiPlayer niPlayer => player.GetModPlayer<NiPlayer>();
        public Vector2 ToMouse => Main.MouseWorld - player.Center;
        public float ai0 { get => Projectile.ai[0]; set => Projectile.ai[0] = value; }
        public float ai1 { get => Projectile.ai[1]; set => Projectile.ai[1] = value; }
        public float ai2 { get => Projectile.ai[2]; set => Projectile.ai[2] = value; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">���</param>
        /// <param name="height">�߶�</param>
        /// <param name="damage">�˺�</param>
        /// <param name="damageClass">�˺�����</param>
        /// <param name="knockBack">����</param>
        /// <param name="friendly">���Ϊtrue�����˺��ж�npc</param>
        /// <param name="hostile">���Ϊtrue�����˺���Һ��Ѻ�npc</param>
        /// <param name="maxPenetrate">��Ļ���͸��,���޴�Ϊ-1</param>
        /// <param name="extraUpdates">������´���</param>
        /// <param name="aistyle">ai����</param>
        /// <param name="scale">��Ļ�Ŵ���</param>
        /// <param name="timeLeft">���ʱ�䣬��֡����</param>
        /// <param name="hide">�Ƿ�������ͼ</param>
        /// <param name="minion">�Ƿ�Ϊ�ٻ���</param>
        /// <param name="tileCollide">�Ƿ��������,falseΪ����</param>
        /// <param name="ignoreWater">�Ƿ�����ˮ��,trueΪ����</param>
        /// <param name="usesLocalNPCImmunity">�Ƿ�ʹ�ö����޵�֡,trueΪʹ��</param>
        /// <param name="localNPCHitCooldown">�����޵�֡</param>
        public void QuickSD(
            int width, int height, int damage, DamageClass damageClass, float knockBack,
            bool friendly, bool hostile, int maxPenetrate = 1, int extraUpdates = 0, int aistyle = -1, float scale = 1f, int timeLeft = 1145141919,
            bool hide = false, bool minion = false, bool tileCollide = false, bool ignoreWater = false,
            bool usesLocalNPCImmunity = true, int localNPCHitCooldown = 20)
        {
            Projectile.width = width;
            Projectile.height = height;
            Projectile.damage = damage;
            Projectile.DamageType = damageClass;
            Projectile.friendly = friendly;
            Projectile.hostile = hostile;
            Projectile.knockBack = knockBack;
            Projectile.maxPenetrate = maxPenetrate;
            Projectile.penetrate = maxPenetrate;
            Projectile.scale = scale;
            Projectile.timeLeft = timeLeft;
            Projectile.aiStyle = aistyle;
            Projectile.extraUpdates = extraUpdates;
            Projectile.hide = hide;
            Projectile.minion = minion;
            Projectile.tileCollide = tileCollide;
            Projectile.ignoreWater = ignoreWater;
            Projectile.usesLocalNPCImmunity = usesLocalNPCImmunity;
            Projectile.localNPCHitCooldown = localNPCHitCooldown;
            hitcooldown = Projectile.localNPCHitCooldown;
        }

        public int hitcooldown;
    }
}

