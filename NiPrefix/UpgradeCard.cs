using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Items.Weapons;
using Ni.Items.Accessories;
using Ni.NiModPlayer;
using Ni.Items.AccEffects;

namespace Ni.NiPrefix
{
    public class UpgradeCard: ModPrefix
    {
        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs("");
        public override PrefixCategory Category => PrefixCategory.Custom;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");
            base.SetStaticDefaults();
        }
        public override void Apply(Item item)
        {
            Player player = Main.player[Main.myPlayer];
            player.TryGetModPlayer<CardPlayer>(out CardPlayer cplr);
            if (cplr != null)
            {
                if (item.type == ModContent.ItemType<Barricade>())
                {
                    CardPlayer.Upgraded[0] = true;
                }
                if (item.type == ModContent.ItemType<ATC>())
                {
                    CardPlayer.Upgraded[1] = true;
                }
                if (item.type == ModContent.ItemType<Electrodynamics>())
                {
                    CardPlayer.Upgraded[2] = true;
                }
                if (item.type == ModContent.ItemType<Fasting>())
                {
                    CardPlayer.Upgraded[3] = true;
                }
            }
            item.SetNameOverride(item.Name + "+");
            base.Apply(item);
        }
        
    }
}

