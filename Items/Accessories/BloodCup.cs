using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Ni.Core;
using Ni.Items.AccEffects;

namespace Ni.Items.Accessories
{
    public class BloodCup:BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Pink, false,18);
        }
        static int count = 0;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer(out AccBloodCup accbc);
            if (accbc.BloodCupCount < 1)
            {
                count++;
                if (count > 14)
                {
                    count = 0;
                    accbc.BloodCupCount++;
                }
            }
            player.GetCritChance(DamageClass.Generic) += 5f;
        }
    }
}
