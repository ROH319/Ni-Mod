using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.NiModPlayer;
using Ni.Buffs;

namespace Ni.Items.Accessories
{
    /*
    public class EmotionChip : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Yellow, false);
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer(out NiPlayer niPlayer);
            player.GetDamage(DamageClass.Summon) += 0.15f;
            //player.GetCritChance(DamageClass.Summon) += 5f;
            niPlayer.EmotionChip = true;
            if (player.HasBuff<EmotionChipBuff>())
            {
                player.GetCritChance(DamageClass.Summon) += 100f;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Nanites, 10)
                .AddIngredient(ItemID.SummonerEmblem)
                .AddTile(ItemID.MythrilAnvil)
                .Register();
        }
    }*/
}

