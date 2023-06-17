using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Ni.NiModPlayer;
using System.Collections.Generic;
using Ni.NiGlobalProj;

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
        public override bool InstancePerEntity => true;
        public bool Scatter = false;

        public List<int> DontSplitProjs = new List<int> { 714, 615 };
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            
            if (Main.LocalPlayer.TryGetModPlayer<AccScatterBullets>(out AccScatterBullets sb) && sb.ScatterBullets && !projectile.minion && !projectile.sentry
                && Main.LocalPlayer.heldProj != projectile.whoAmI
                && !projectile.hostile && !DontSplitProjs.Contains(projectile.type))
            {
                if ((source is EntitySource_ItemUse parent && parent.Item.type == Main.player[projectile.owner].HeldItem.type)
                || (source is EntitySource_ItemUse_WithAmmo parent1 && parent1.Item.type == Main.player[projectile.owner].HeldItem.type))
                {
                    Scatter = true;
                    projectile.damage /= 2;
                    var newsource = projectile.GetSource_FromThis();
                    Projectile proj1 = Projectile.NewProjectileDirect(newsource, projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(10)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);
                    Projectile proj2 = Projectile.NewProjectileDirect(newsource, projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(-10)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    //��ִ�з����䵯��onspawn,��ִ�з����䵯��gproj��onspawn�����ŵ���һ�е�onspawn
                }
            }
            base.OnSpawn(projectile, source);
        }
    }
}

