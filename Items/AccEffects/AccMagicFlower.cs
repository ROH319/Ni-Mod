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
        public float FlowerHealMul = 1.5f;
        public float FlowerPotionHealMul = 1.5f;
        public bool MagicFlower;
        public override void Load()
        {
            Terraria.On_Player.Heal += Player_Heal;
            Terraria.On_Player.UpdateLifeRegen += Player_UpdateLifeRegen;
            base.Load();
        }
        public override void Unload()
        {
            Terraria.On_Player.Heal -= Player_Heal;
            Terraria.On_Player.UpdateLifeRegen -= Player_UpdateLifeRegen;
            base.Unload();
        }
        private void Player_UpdateLifeRegen(Terraria.On_Player.orig_UpdateLifeRegen orig, Player self)
        {
            orig(self);
            if (self.TryGetModPlayer<AccMagicFlower>(out AccMagicFlower mf) && mf.MagicFlower)
            {
                self.lifeRegen += self.lifeRegen / 2;
            }
        }

        private void Player_Heal(Terraria.On_Player.orig_Heal orig, Player self, int amount)
        {
            bool magicflower = self.TryGetModPlayer<AccMagicFlower>(out AccMagicFlower mf) && mf.MagicFlower;
            orig(self, (int)(magicflower ? amount * FlowerHealMul : amount));
        }

        public override void GetHealLife(Item item, bool quickHeal, ref int healValue)
        {
            healValue = (int)(healValue * (MagicFlower ? FlowerPotionHealMul : 1));
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

