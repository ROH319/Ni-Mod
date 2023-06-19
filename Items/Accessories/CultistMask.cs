using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Ni.Helpers;

namespace Ni.Items.Accessories
{
    public class CultistMask : BaseAccessory
    {
        public int cooldown;
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Cyan, false,20);
            cooldown = 300;
            base.SetDefaults();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (cooldown > 0)
            {
                cooldown--;
            }
            if (cooldown == 0)
            {
                cooldown = 300;
                CombatText.NewText(player.getRect(), Color.White, "咔！咔咔！");
                SoundEngine.PlaySound(AssetHelper.Kakaa, player.Center);
            }
            base.UpdateAccessory(player, hideVisual);
        }
        public override void UpdateVanity(Player player)
        {
            if (cooldown > 0)
            {
                cooldown--;
            }
            if (cooldown == 0)
            {
                cooldown = 300;
                CombatText.NewText(player.getRect(), Color.White, "咔！咔咔！");
                SoundEngine.PlaySound(AssetHelper.Kakaa, player.Center);
            }
            base.UpdateVanity(player);
        }
    }
}

