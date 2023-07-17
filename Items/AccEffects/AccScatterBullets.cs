using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.Core;
using System.Collections.Generic;

namespace Ni.Items.AccEffects
{
    public class AccScatterBullets : BaseAcc
    {
        public bool ScatterBullets;
        public override void ResetEffects()
        {
            ScatterBullets = false;
            base.ResetEffects();
        }
    }

    public class ScatterBulletsGProj : NiGProj
    {
        public int SplitDamageMul = 2;
        public bool Scatter = false;
        public List<int> DontSplitProjs = new List<int> { 714, 615 };
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (!CanSplit(projectile, source)) return;
            Scatter = true;
            projectile.damage /= SplitDamageMul;
            var newsource = projectile.GetSource_FromThis();
            Projectile proj1 = Projectile.NewProjectileDirect(newsource, projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(10)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);
            Projectile proj2 = Projectile.NewProjectileDirect(newsource, projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(-10)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

            //��ִ�з����䵯��onspawn,��ִ�з����䵯��gproj��onspawn�����ŵ���һ�е�onspawn
            base.OnSpawn(projectile, source);
        }
        public bool CanSplit(Projectile projectile, IEntitySource source) => 
            Main.LocalPlayer.TryGetModPlayer<AccScatterBullets>(out AccScatterBullets sb)
            && sb.ScatterBullets 
            && !projectile.minion 
            && !projectile.sentry
            && Main.LocalPlayer.heldProj != projectile.whoAmI
            && !projectile.hostile 
            && !DontSplitProjs.Contains(projectile.type) 
            && ((source is EntitySource_ItemUse parent && parent.Item.type == Main.player[projectile.owner].HeldItem.type)
                || (source is EntitySource_ItemUse_WithAmmo parent1 && parent1.Item.type == Main.player[projectile.owner].HeldItem.type));
    }
}

