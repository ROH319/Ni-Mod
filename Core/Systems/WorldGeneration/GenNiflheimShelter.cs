using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using Ni.NPCs.Bosses.NiflheimBoss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Ni.Core.Systems.WorldGeneration
{
    public partial class NiWorld
    {
        public static Point ShelterCenter;
        public static Rectangle ShelterRec;
        public async void GenNiflheimShelter(GenerationProgress progress,GameConfiguration configuration)
        {
            progress.Message = "生成冰雪庇护所";
            int shelterCenter_x = (GenVars.snowOriginLeft + GenVars.snowOriginRight) / 2;
            int shelterCenter_y = (int)MathHelper.Lerp(GenVars.snowBottom, GenVars.snowTop, 0.25f);

            Texture2D shelterTex = AssetHelper.GetTex(AssetHelper.NiflheimPath + "NiShelter");

            int genOrigin_x = shelterCenter_x - shelterTex.Width / 2;
            int genOrigin_y = shelterCenter_y - shelterTex.Height / 2;

            ShelterCenter = new Point(genOrigin_x + 45, genOrigin_y + 28);

            Dictionary<Color, Vector2> shelterDic = new Dictionary<Color, Vector2>()
            {
                [new Color(219, 100, 100)] = new Vector2(TileID.IceBrick, 0),
                [new Color(224, 29, 100)] = new Vector2(TileID.Platforms,35),
                [new Color(255, 0, 0)] = new Vector2(ModContent.TileType<ShelterAltar>(),0),
                [new Color(0,0,0)] = new Vector2(-2,0),
                [new Color(0,89,255)] = new Vector2(-2,0)
            };

            await Task.Run(() =>
            {
                Main.QueueMainThreadAction(() =>
                {
                    Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                    //生成主体地形
                    Texture2DGenerator shelterGenerator = Texture2DGenerator.GetTexGenerator(shelterTex, shelterDic);
                    shelterGenerator.Generate(genOrigin_x, genOrigin_y, true);


                });
            });
        }
    }
}
