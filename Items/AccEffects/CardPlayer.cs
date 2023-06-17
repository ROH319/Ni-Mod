using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;

namespace Ni.Items.AccEffects
{
    public class CardPlayer : BaseAcc
    {
        public static bool[] HasUpgradedItem = new bool[4];
        public static bool[] Upgraded = new bool[4];
        public override void Initialize()
        {
            for (int i = 0; i < 4; i++)
            {
                Upgraded[i] = false;
            }
            base.Initialize();
        }
        public override void ResetEffects()
        {
            for (int i = 0; i < 4; i++)
            {
                HasUpgradedItem[i] = false;
            }
            base.ResetEffects();
        }

        public override void SaveData(TagCompound tag)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Upgraded[i])
                {
                    tag[$"Upgraded{i}"] = true;
                }
            }
            base.SaveData(tag);
        }
        public override void LoadData(TagCompound tag)
        {
            for (int i = 0; i < 4; i++)
            {
                Upgraded[i] = tag.ContainsKey($"Upgraded{i}");
            }
            base.LoadData(tag);
        }

    }
}

