using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;

namespace Ni.Buffs
{/*
    public class EliteTaunted : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            

            base.SetStaticDefaults();
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            //EliteNPC eliteNPC = 
            #region ²»ÐÐ
            EliteNPC eliteNPC1 = null;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc1 = Main.npc[i];
                EliteNPC eliteNPC2;
                npc1.TryGetGlobalNPC(out eliteNPC2);
                if (!eliteNPC2.IsElite)
                {
                    break;
                }
                else
                {
                    if (eliteNPC2.HasElite(eliteNPC2, EliteID.taunt))
                    {
                        eliteNPC1 = eliteNPC2;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            #endregion
            if (eliteNPC1 == null)
            {
                npc.buffTime[buffIndex] = 0;
            }
        }

    }*/
}

