using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ni.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ID;
using Ni.NPCs.Bosses.NiflheimBoss;

namespace Ni.Core.Systems.WorldGeneration
{
    public partial class NiWorld : ModSystem
    {
        
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            //int IceBiomeIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Generate Ice Biome"));
            int finalCleanUp = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            //if (ShiniesIndex != -1)
            {
                //tasks.Insert(finalCleanUp - 1, new PassLegacy("Niflheim Shelter", GenNiflheimShelter));
                tasks.Insert(finalCleanUp + 1, new PassLegacy("Niflheim Shelter", delegate (GenerationProgress progress, GameConfiguration configuration)
                {
                    progress.Message = "生成冰雪庇护所";
                    int shelterCenter_x = (GenVars.snowOriginLeft + GenVars.snowOriginRight) / 2;
                    int shelterCenter_y = (int)MathHelper.Lerp(GenVars.snowBottom, GenVars.snowTop, 0.25f);

                    Texture2D shelterTex = AssetHelper.GetTex(AssetHelper.NiflheimPath + "NiShelter");

                    int genOrigin_x = shelterCenter_x - shelterTex.Width / 2;
                    int genOrigin_y = shelterCenter_y - shelterTex.Height / 2;

                    ShelterCenter = new Point(genOrigin_x + 34, genOrigin_y + 21);

                    //清理
                    for(int x = genOrigin_x; x < genOrigin_x + shelterTex.Width; x++)
                    {
                        for(int y = genOrigin_y; y < genOrigin_y + shelterTex.Height; y++)
                        {
                            Main.tile[x, y].ClearEverything();
                            WorldGen.PlaceWall(x, y, ModContent.WallType<ShelterWall>());
                        }
                    }

                    for (int offsetX = 0; offsetX < shelterTex.Width; offsetX++) 
                    { 
                        WorldGen.PlaceTile(genOrigin_x + offsetX, genOrigin_y, TileID.IceBrick);
                        WorldGen.PlaceTile(genOrigin_x + offsetX, genOrigin_y + shelterTex.Height, TileID.IceBrick);
                    }
                    for(int offsetY = 0;offsetY < shelterTex.Height; offsetY++)
                    {
                        WorldGen.PlaceTile(genOrigin_x, genOrigin_y + offsetY, TileID.IceBrick);
                        WorldGen.PlaceTile(genOrigin_x + shelterTex.Width, genOrigin_y + offsetY, TileID.IceBrick);
                    }

                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 3 + offsetX, genOrigin_y + 12, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 3 + offsetX, genOrigin_y + 22, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 3 + offsetX, genOrigin_y + 32, TileID.Platforms, style: 35);
                    
                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 51 + offsetX, genOrigin_y + 12, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 51 + offsetX, genOrigin_y + 22, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 14; offsetX++) WorldGen.PlaceTile(genOrigin_x + 51 + offsetX, genOrigin_y + 32, TileID.Platforms, style: 35);

                    for (int offsetX = 0; offsetX < 26; offsetX++) WorldGen.PlaceTile(genOrigin_x + 21 + offsetX, genOrigin_y + 6, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 26; offsetX++) WorldGen.PlaceTile(genOrigin_x + 21 + offsetX, genOrigin_y + 16, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 26; offsetX++) WorldGen.PlaceTile(genOrigin_x + 21 + offsetX, genOrigin_y + 26, TileID.Platforms, style: 35);
                    for (int offsetX = 0; offsetX < 26; offsetX++) WorldGen.PlaceTile(genOrigin_x + 21 + offsetX, genOrigin_y + 36, TileID.Platforms, style: 35);
                    
                    WorldGen.PlaceTile(genOrigin_x + 33, genOrigin_y + 25, ModContent.TileType<ShelterAltar>());
                    
                }));
            }
            base.ModifyWorldGenTasks(tasks, ref totalWeight);
        }
        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("NiflheimShelterCenterX", ShelterCenter.X);
            tag.Add("NiflheimShelterCenterY", ShelterCenter.Y);
        }
        public override void LoadWorldData(TagCompound tag)
        {
            ShelterCenter.X = tag.Get<int>("NiflheimShelterCenterX");
            ShelterCenter.Y = tag.Get<int>("NiflheimShelterCenterY");
        }
    }
}
