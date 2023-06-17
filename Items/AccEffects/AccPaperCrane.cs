using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiGlobalNPC;
using Terraria.DataStructures;
using Ni.NiGlobalProj;

namespace Ni.Items.AccEffects
{
    public class AccPaperCrane : BaseAcc
    {
        public float PaperCraneMul = 0.75f;
        public bool PaperCrane;
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            var source = npc.GetGlobalNPC<NiGNPC>().entitySource;
            EntitySource_Parent parent = source is EntitySource_Parent ? source as EntitySource_Parent : null;
            if (PaperCrane && (npc.lifeMax == 1 ? (NPC)parent?.Entity : npc).HasBuff(BuffID.Venom))
            {
                modifiers.FinalDamage *= (PaperCrane ? PaperCraneMul : 1);
            }
            base.ModifyHitByNPC(npc, ref modifiers);
        }
        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            if (PaperCrane && proj.GetGlobalProjectile<NiGProj>().entitySource is EntitySource_Parent parent && parent.Entity is NPC npc && npc.HasBuff(BuffID.Venom))//‘¥npc”–À·–‘∂æ“∫debuff
            {
                modifiers.FinalDamage *= (PaperCrane ? PaperCraneMul : 1);
            }
            base.ModifyHitByProjectile(proj, ref modifiers);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (PaperCrane && Main.rand.NextBool(6))
            {
                target.AddBuff(BuffID.Venom, 15 * 60);
            }
            base.OnHitNPC(target, hit, damageDone);
        }
        public override void ResetEffects()
        {
            PaperCrane = false;
            base.ResetEffects();
        }
    }
}

