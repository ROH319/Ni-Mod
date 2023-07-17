using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.Items.AccEffects
{
    public class AccBloodCup : BaseAcc
    {
        public int HealAmount = 2;
        public int BloodCupCount;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (hit.Crit && BloodCupCount > 0)
            {
                Player.Heal(HealAmount);
                BloodCupCount--;
            }
            base.OnHitNPC(target, hit, damageDone);
        }
    }
}

