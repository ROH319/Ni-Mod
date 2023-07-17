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

namespace Ni.Items.AccEffects
{
    public class AccSeeri : BaseAcc
    {

        public bool Seeri;
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)/* tModPorter If you don't need the Projectile, consider using ModifyHitNPC instead */
        {
            if (Seeri && proj.DamageType == DamageClass.Summon && Main.rand.NextBool(20))
            {
                modifiers.SetCrit();
            }
        }

        public override void ResetEffects()
        {
            Seeri = false;
            base.ResetEffects();
        }
    }
    public class SeeriGNPC : NiGNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.TryGetGlobalProjectile<SeeriGProj>(out SeeriGProj se) && se.Seeried && projectile.npcProj && Main.rand.NextBool(20))
            {
                modifiers.SetCrit();//TO TEST
            }
            base.ModifyHitByProjectile(npc, projectile, ref modifiers);
        }
    }
    public class SeeriGProj : NiGProj
    {
        public bool Seeried = false;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent && !projectile.hostile)
            {
                EntitySource_Parent parentSource = source as EntitySource_Parent;
                if (parentSource != null && parentSource.Entity is Projectile && (parentSource.Entity as Projectile).GetGlobalProjectile<SeeriGProj>().Seeried)
                {
                    projectile.friendly = true;
                    projectile.npcProj = true;
                }
            }
            base.OnSpawn(projectile, source);
        }
        public override bool PreAI(Projectile projectile)
        {
            if (Seeried && projectile.type is 134 or 137 or 140 or 143 or 776 or 780 or 784 or 787 or 790 or 793 or 796 or 799)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                projectile.friendly = true;
                projectile.npcProj = true;
                NPC target = projectile.FindTargetWithinRange(1000f, true);
                if (target != null)
                {
                    // 目标速度
                    var targetVel = Vector2.Normalize(target.Center - projectile.Center) * 10f;
                    // 加权平均 1份目标速度和10份当前速度
                    projectile.velocity = (targetVel * 3 + projectile.velocity * 8) / 11f;
                }

                return true;
            }
            return base.PreAI(projectile);
        }
        public override void PostAI(Projectile projectile)
        {
            if (Seeried)
            {
                projectile.friendly = true;
                projectile.hostile = false;
            }
        }
    }
}

