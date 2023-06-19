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
    public class AccATC : CardPlayer
    {
        public int ATC;
        public override void ResetEffects()
        {
            ATC = 0;
            base.ResetEffects();
        }
    }
    public class ATCGProj : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {

            if (projectile.owner == Main.LocalPlayer.whoAmI && projectile.friendly && projectile.damage > 0 && !projectile.hostile
                && projectile.active
                && source is not EntitySource_Misc
                && Main.LocalPlayer.TryGetModPlayer<AccATC>(out AccATC atc) && atc.ATC > 0)
            {
                //Main.NewText($"{Main.time} {source.GetType()}");
                foreach (NPC npc in Main.npc)
                {
                    if (npc.active && npc.CanBeChasedBy())
                    {
                        NPC truenpc = npc.realLife == -1 ? npc : Main.npc[npc.realLife];
                        for (int i = 0; i < atc.ATC; i++)
                        {
                            int damage = (CardPlayer.HasUpgradedItem[1] ? 8 : 4) * (npc.type == NPCID.SolarCrawltipedeTail ? 10 : 1);
                            //npc.StrikeNPCNoInteraction(3, 0f, 0);
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
            }
            base.OnSpawn(projectile, source);
        }
    }
}

