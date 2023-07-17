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
using Ni.Items.Accessories;

namespace Ni.Items.AccEffects
{
    public class AccATC : CardPlayer
    {
        public bool ATCEnabled;
        public override void ResetEffects()
        {
            ATCEnabled = false;
            base.ResetEffects();
        }
    }
    public class ATCGProj : GlobalProjectile
    {
        public int DamageofATC = 4;
        public int DamageofATC_UPGRADED = 8;
        public int DamageSolarCrawltipedeMul = 10;
        public override bool InstancePerEntity => true;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.owner == Main.LocalPlayer.whoAmI && projectile.friendly && projectile.damage > 0 && !projectile.hostile
                && projectile.active
                && source is not EntitySource_Misc
                && Main.LocalPlayer.TryGetModPlayer<AccATC>(out AccATC atc) && atc.ATCEnabled)
            {
                //Main.NewText($"{Main.time} {source.GetType()}");
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && npc.CanBeChasedBy())
                    {
                        DealDamage2NPC(npc, (CardPlayer.HasUpgradedItem[1] ? DamageofATC_UPGRADED : DamageofATC) * (npc.type == NPCID.SolarCrawltipedeTail ? DamageSolarCrawltipedeMul : 1));
                    }
                }
            }
            base.OnSpawn(projectile, source);
        }
        public void DealDamage2NPC(NPC npc,int damage)
        {
            NPC truenpc = npc.realLife == -1 ? npc : Main.npc[npc.realLife];
            CombatText.NewText(truenpc.getRect(), Color.Red, damage);
            truenpc.life -= damage;
            Main.LocalPlayer.addDPS(damage);
            if (truenpc.life < 0)
            {
                truenpc.checkDead();
            }
        }
    }
}

