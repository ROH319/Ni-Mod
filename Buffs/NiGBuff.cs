using Microsoft.Xna.Framework;
using Ni.Core;
using Ni.Items.Accessories;
using Ni.Items.Weapons;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Ni.Buffs
{
    public class NiGBuff:GlobalBuff
    {
        public int count;
        public int cooldown;
        
        public override bool ReApply(int type, NPC npc, int time, int buffIndex)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer(out NiPlayer niPlayer);
            npc.TryGetGlobalNPC(out NiGNPC niGNPC);
            //if (type == BuffID.Poisoned)
            //{
            //    npc.buffTime[buffIndex] += time;
            //    return true;
            //}
            return false;
        }

        public override void Update(int type, NPC npc, ref int buffIndex)
        {
            Player player = Main.player[Main.myPlayer];
            if(cooldown == 0)
            {
                cooldown = 60;
            }
            cooldown--;

            //if (type == BuffID.Poisoned)
            //{
            //    //npc.lifeRegen += 8;
            //    if (npc.buffTime[buffIndex] > 9999)
            //    {
            //        npc.buffTime[buffIndex] = 9999;
            //    }
            //    if(cooldown == 0)
            //    {
            //        int damage = npc.buffTime[buffIndex];
            //        if (!npc.immortal || npc.realLife != -1)
            //        {
            //            NPC truenpc = npc.realLife == -1 ? npc : Main.npc[npc.realLife];
            //            if (truenpc.life > damage)
            //            {
            //                truenpc.life -= damage;
            //            }
            //            else
            //            {
            //                truenpc.life = 0;
            //                truenpc.checkDead();
            //            }
            //            CombatText.NewText(truenpc.getRect(), Color.Green, damage, true);
            //            //npc.StrikeNPCNoInteraction(damage, 0f, 0, false, true,true);
            //            player.addDPS(damage);
            //            truenpc.buffTime[buffIndex] /= 2;
            //        }
            //    }
            //    if (npc.buffTime[buffIndex] < 1)
            //    {
            //        npc.DelBuff(buffIndex);
            //    }
            //    npc.buffTime[buffIndex] += 1;
            //    return;
            //}
            base.Update(type, npc, ref buffIndex);
        }
    }
}
