using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Ni.Core.Systems
{
    public class TitleSystem : ModSystem
    {

        public override void PostSetupContent()
        {
            if (!Main.dedServ)
            {
                Main.instance.Window.Title = "泰拉瑞亚：你说得对，但是《TModloader》是由Tml团队开发的一个知名游戏引擎";
            }
            base.PostSetupContent();
        }
    }
}
