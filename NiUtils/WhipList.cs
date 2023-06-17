using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace Ni.NiUtils
{
    public static class WhipList
    {
        public static List<int> VanillaWhipProjList;
        public static void Load()
        {
            VanillaWhipProjList = new List<int>
            {
                ProjectileID.ThornWhip,
                ProjectileID.BlandWhip,
                ProjectileID.BoneWhip,
                ProjectileID.FireWhip,
                ProjectileID.CoolWhip,
            };
        }
        public static void Unload()
        {
            VanillaWhipProjList = null;
        }
    }
}
