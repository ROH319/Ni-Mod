using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;

namespace Ni.Items.AccEffects
{
    public class AccEmergencyTriage : BaseAcc
    {
        public float EmergencyMul = 0.5f;
        public bool EmergencyTriage;
        
        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            healValue = (int)(healValue * (EmergencyTriage ? EmergencyMul : 1));
            //ÿִ֡��
            base.GetHealLife(item, quickHeal, ref healValue);
        }
        public override void ResetEffects()
        {
            EmergencyTriage = false;
            base.ResetEffects();
        }
    }
    public class EmergencyTriageGItem : NiGItem
    {
        public bool Emergencied;
        public int ImmuneTimeInTicks = 120;
        public override bool? UseItem(Item item, Player player)
        {
            if (player.TryGetModPlayer<AccEmergencyTriage>(out AccEmergencyTriage mf) && mf.EmergencyTriage && item.healLife > 0)
            {
                player.SetImmuneTimeForAllTypes(ImmuneTimeInTicks);
            }
            return base.UseItem(item, player);
        }
    }
}

