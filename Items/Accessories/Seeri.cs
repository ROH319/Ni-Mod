using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;
using Ni.Projectiles.Minions;
using Ni.Buffs;
using Ni.Items.AccEffects;
using Terraria.DataStructures;

namespace Ni.Items.Accessories
{
    public class Seeri : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSD(30, 19, 0, DamageClass.Default, 0, 0, false, 0, 1, ItemRarityID.LightRed, false, false, true, true, true, Item.sellPrice(0, 16));
            Item.useAmmo = AmmoID.Rocket;
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccSeeri>(out AccSeeri se);
            se.Seeri = true;
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.AddBuff(ModContent.BuffType<SeeriBuff>(), 2);
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SeeriMinion>()] < 1)
            {
                Projectile p = Projectile.NewProjectileDirect(player.GetSource_Accessory(Item), player.Center, Vector2.Zero, ModContent.ProjectileType<SeeriMinion>(), 40, 5f, player.whoAmI);
                p.damage += 0;
            }
            base.UpdateAccessory(player, hideVisual);
        }
    }
}

