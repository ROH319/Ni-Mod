using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Buffs;
using Ni.Core;

namespace Ni.Items.AccEffects
{
    public class AccMarbles : BaseAcc
    {
        public bool Marbles;
        public override void ResetEffects()
        {
            Marbles = false;
            base.ResetEffects();
        }
    }
    public class MarblesGNPC : NiGNPC
    {
        public bool Marbled;
        public float MarbleMul = 1.3f;

        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            player.TryGetModPlayer<AccMarbles>(out AccMarbles mplr);
            if (!FirstAttacked)
            {
                if (mplr.Marbles)
                {
                    npc.AddBuff(ModContent.BuffType<MarbledBuff>(), 2 * 60);
                }
                FirstAttacked = true;
            }
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            Main.player[projectile.owner].TryGetModPlayer<AccMarbles>(out AccMarbles mplr);
            if (!FirstAttacked)
            {
                if (mplr.Marbles)
                {
                    npc.AddBuff(ModContent.BuffType<MarbledBuff>(), 2 * 60);
                }
                FirstAttacked = true;
            }
        }
        public override void ModifyHitNPC(NPC npc, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Marbled)
            {
                modifiers.FinalDamage *= MarbleMul;
            }
            base.ModifyHitNPC(npc, target, ref modifiers);
        }
        public override void ResetEffects(NPC npc)
        {
            Marbled = false;
            base.ResetEffects(npc);
        }
    }
}

