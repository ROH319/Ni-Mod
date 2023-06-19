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
    public class AccMagicFlower : BaseAcc
    {

        public float FlowerMul = 1.5f;
        public bool MagicFlower;

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            healValue = (int)(healValue * (MagicFlower ? FlowerMul : 1));
            //Ã¿Ö¡Ö´ÐÐ
            base.GetHealLife(item, quickHeal, ref healValue);
        }
        public override void ResetEffects()
        {
            MagicFlower = false;
            base.ResetEffects();
        }
    }
    public class MagicFlowerGProj : NiGProj
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.type == ProjectileID.VampireHeal || projectile.type == ProjectileID.SpiritHeal)
            {
                if (Main.LocalPlayer.TryGetModPlayer<AccMagicFlower>(out AccMagicFlower mf) && mf.MagicFlower)
                {
                    projectile.ai[1] += projectile.ai[1] / 2;
                }
            }
            base.OnSpawn(projectile, source);
        }
    }
}

