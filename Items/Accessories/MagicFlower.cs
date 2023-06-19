using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Ni.Core;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using Ni.Items.AccEffects;

namespace Ni.Items.Accessories
{
    public class MagicFlower : BaseAccessory
    {
        public override void SetDefaults()
        {
            QuickSDAc(ItemRarityID.Lime, false,14);
            base.SetDefaults();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.TryGetModPlayer<AccMagicFlower>(out AccMagicFlower mf);
            mf.MagicFlower = true;
            base.UpdateAccessory(player, hideVisual);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Name == "Tooltip0");
            if (!PlayerInput.GetPressedKeys().Contains(Keys.LeftControl) && !PlayerInput.GetPressedKeys().Contains<Keys>(Keys.RightControl))
            {
                line.Text = line.Text + "\n" + Language.GetTextValue("Mods.Ni.ItemExtra.ExtraTooltips");
            }
            else
            {
                line.Text = Language.GetTextValue("Mods.Ni.ItemExtra.MagicFlower");
            }
            line.Text += "\n" + Language.GetTextValue("Mods.Ni.ItemExtra.MagicFlowerLoot");
            base.ModifyTooltips(tooltips);
        }
    }
}

