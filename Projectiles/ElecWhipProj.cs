using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Projectiles;
using Terraria.DataStructures;
using Terraria.GameContent;
using System.Collections.Generic;
using rail;
using System.Linq;
using Terraria.Audio;
using Ni.Buffs;
using Ni.Helpers;

namespace Ni.Projectiles
{
    public class ElecWhipProj : BaseRotateProj
    {
        public NPC TargetNPC;
        public override string Texture => AssetHelper.TransparentImg;
        public List<Vector2> Nodes = new();
        public override void SetDefaults()
        {
            QuickSD(15, 15, 48, DamageClass.SummonMeleeSpeed, 5f, true, false, -1, 0, -1, 1f, 6, false, false, false, false, true, -1);
            Projectile.ArmorPenetration = 114514;
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            TargetNPC = Projectile.FindTargetWithinRange(5f);
            if (ai1 == -1) // 本体，生成其他弹幕
            {
                /*Vector2 tomouse = Main.MouseWorld - Projectile.Center;
                tomouse.Normalize();
                foreach (NPC npc in Main.npc)
                {
                    if (npc != null && npc.active && !npc.friendly && NiUtil.CheckAABBvLineColliding(Projectile.Center, Projectile.Center + tomouse * ai0, 400, npc.getRect()))
                    {
                        NPCPos.Add(npc.Center);
                    }
                }
                
                NPCPos.RemoveAll(x => x == Vector2.Zero);
                NPCPos.Sort((x, y) => { return (Vector2.Distance(x, player.Center) > Vector2.Distance(y, player.Center)) ? 1 : 0; }); // 按距离升序排列
                */
                NPC npc = Projectile.FindTargetWithinRange(ai0, true);
                if(npc != null)
                {
                    TargetNPC = npc;
                    var p = Projectile.NewProjectileDirect(source, npc.Center, Vector2.Zero, Projectile.type, Projectile.damage, Projectile.knockBack, player.whoAmI, -1, Projectile.whoAmI);
                }
                /*int lastindex = Projectile.whoAmI;
                float scale = Projectile.scale;
                foreach(Vector2 pos in NPCPos)
                {
                    var p = Projectile.NewProjectileDirect(source, pos, Projectile.velocity, Type, Projectile.damage, Projectile.knockBack, player.whoAmI, -1, lastindex);
                    lastindex = p.whoAmI;
                    if(scale > 0.1f)
                    {
                        scale -= 0.2f;
                    }
                    p.scale = scale;
                }*/
            }
            else
            {
                if (source is EntitySource_OnHit && float.TryParse(source.Context.ToString(),out float iscale))
                {
                    Projectile.scale = iscale - 0.2f;
                }
                Projectile parent = Main.projectile[(int)ai1];
                if (parent.ai[1] == -1 && parent.active)
                {
                    SoundEngine.PlaySound(AssetHelper.ElecWhipShoot, player.Center);
                    foreach (NPC npc in Main.npc)
                    {
                        if (!npc.immortal && npc != null && npc.active && !npc.friendly && Vector2.Distance(npc.Center, Projectile.Center) < 200 * player.whipRangeMultiplier && npc.whoAmI != (parent.ModProjectile as ElecWhipProj).TargetNPC.whoAmI && Projectile.scale > 0.5f && Collision.CanHitLine(npc.Center, 0, 0, Projectile.Center, 0, 0))
                        {
                            TargetNPC = npc;
                            var p = Projectile.NewProjectileDirect(Projectile.GetSource_OnHit(npc,$"{Projectile.scale}"), npc.Center, Vector2.Zero, Projectile.type, Projectile.damage / 2, Projectile.knockBack, player.whoAmI, -1, Projectile.whoAmI);
                        }
                    }
                }
                Nodes.Add(Projectile.Center);
                for(float i = 0.05f; i < 1f;i += (source is EntitySource_OnHit) ? 0.5f : Main.rand.NextFloat(0.05f,0.1f))
                {
                    Nodes.Add(Vector2.Lerp(Projectile.Center, Main.projectile[(int)ai1].Center, i) + Helpers.NiUtils.Vector2RandUnit(Main.rand.Next(2, (source is EntitySource_OnHit) ? 8 : 12), 0, MathHelper.TwoPi));
                }
                Nodes.Add(Main.projectile[(int)ai1].Center);
            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Nodes.RemoveAll(x => x == Vector2.Zero);
            if (ai0 != -1) return base.Colliding(projHitbox, targetHitbox);

            bool[] canhit = new bool[Nodes.Count];
            for (int i = 0; i < Nodes.Count - 2; i++)
            {
                canhit[i] = Helpers.NiUtils.CheckAABBvLineColliding(Nodes[i], Nodes[i + 1], (int)(8 * Projectile.scale), targetHitbox);
            }
            return canhit.ToList().Find(x => x == true);
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.wet)
            {
                modifiers.SetCrit();
            }
            base.ModifyHitNPC(target, ref modifiers);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for(int i = 0; i < 5; i++)
            {
                Dust d = Dust.NewDustPerfect(target.Center, MyDustId.ElectricCyan, Helpers.NiUtils.Vector2RandUnit(Main.rand.Next(3,8), 0, MathHelper.TwoPi), Scale: 0.5f);
                d.fadeIn = 0.1f;
                d.noGravity = true;
            }
            target.AddBuff(ModContent.BuffType<ElectronicWhipDebuff>(), 6 * 60);
            player.MinionAttackTargetNPC = target.whoAmI;
        }
        public override void AI()
        {
            if(ai1 == -1)
            {
                Projectile.Center = player.Center;
            }
            for(int i = 1;i < Nodes.Count-1; i++)
            {
                Nodes[i] += Helpers.NiUtils.Vector2RandUnit(Main.rand.Next(3, (int)(8 * Projectile.scale)), 0, MathHelper.TwoPi);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D trail = AssetHelper.TrailShape;
            sb.AdditiveBegin(SpriteSortMode.Deferred);
            for (int i = 0; i < Nodes.Count - 1; i++)
            {
                float distance = Vector2.Distance(Nodes[i], Nodes[i + 1]);
                for (float j = 0; j < distance; j += 0.5f)
                {
                    sb.Draw(trail, Vector2.Lerp(Nodes[i], Nodes[i + 1], j / distance) - Main.screenPosition, null, Color.SkyBlue, 0f, trail.Size() / 2, Projectile.scale / 48, 0, 0);
                }
            }
            sb.VanillaBegin();
            return false;
        }
    }
}

