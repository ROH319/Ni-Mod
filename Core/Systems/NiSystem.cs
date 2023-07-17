using Ni.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.Localization;
using Terraria.WorldBuilding;
using Ni.DownWell;

namespace Ni.Core.Systems
{
    public class NiSystem:ModSystem
    {
        public override void OnWorldUnload()
        {
            base.OnWorldUnload();
        }
        public static float UsedMinionSlots;

        //public static ModKeybind FlameKey { get;private set; }

        public override void PostSetupContent()
        {
            //Mod Calamitymod = ModLoader.GetMod("CalamityMod");
            //if(Calamitymod != null)
            //{
                
            //}
            
        }
        public override void ModifyScreenPosition()
        {
            base.ModifyScreenPosition();
        }
        public override void Load()
        {
            //FlameKey = KeybindLoader.RegisterKeybind(Mod, Language.GetTextValue("Mods.Ni.KeyBind.FlameKey"), Keys.F);
            base.Load();
        }
        public override void Unload()
        {
            //FlameKey = null;
        }
        public override void PostUpdateProjectiles()
        {
            Player player = Main.player[Main.myPlayer];
            UsedMinionSlots = player.slotsMinions;
            base.PostUpdateProjectiles();
        }
        public override void AddRecipes()
        {
            RecipeGroup evilbossmaterial = new RecipeGroup(() => "暗影鳞片或组织样本",
                new int[]
                {
                    ItemID.TissueSample,
                    ItemID.ShadowScale
                });
            RecipeGroup.RegisterGroup("EvilBossMaterial", evilbossmaterial);
        }
        public override void PostUpdateDusts()
        {
            //NiUtil.DrawDustTrail();
            base.PostUpdateDusts();
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            
            base.ModifyWorldGenTasks(tasks, ref totalWeight);
        }
    }
}
