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
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="damage">伤害</param>
        /// <param name="damageClass">伤害类型</param>
        /// <param name="knockBack">击退</param>
        /// <param name="friendly">如果为true，会伤害敌对npc</param>
        /// <param name="hostile">如果为true，会伤害玩家和友好npc</param>
        /// <param name="maxPenetrate">弹幕最大穿透数,无限穿为-1</param>
        /// <param name="extraUpdates">额外更新次数</param>
        /// <param name="aistyle">ai类型</param>
        /// <param name="scale">弹幕放大倍数</param>
        /// <param name="timeLeft">存活时间，以帧计算</param>
        /// <param name="hide">是否隐藏贴图</param>
        /// <param name="minion">是否为召唤物</param>
        /// <param name="tileCollide">是否无视物块,false为无视</param>
        /// <param name="ignoreWater">是否无视水体,true为无视</param>
        /// <param name="usesLocalNPCImmunity">是否使用独立无敌帧,true为使用</param>
        /// <param name="localNPCHitCooldown">独立无敌帧</param>
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

