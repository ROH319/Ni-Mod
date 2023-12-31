using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using System.IO;
using Terraria.Utilities;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Steamworks;
using Terraria.ModLoader.IO;

namespace Ni.DownWell
{
    public class DownWellWorldGen : ModSystem
    {
        
        public static bool DownWellWorld = false;
        public override void OnWorldLoad()
        {
            DownWellWorld = false;
            base.OnWorldLoad();
        }
        public override void OnWorldUnload()
        {
            DownWellWorld = false;
            base.OnWorldUnload();
        }
        public override void LoadWorldData(TagCompound tag)
        {
            DownWellWorld = tag.ContainsKey("IsDownwellWorld");
            base.LoadWorldData(tag);
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (DownWellWorld)
            {
                tag["IsDownwellWorld"] = true;
            }
            base.SaveWorldData(tag);
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            if (Main.ActiveWorldFileData.SeedText.ToLower() == "downwell")
            {
                DownWellWorld = true;
                Main.rand = new UnifiedRandom();
                // = Main.rand.Next(999999999);
                //Console.WriteLine("DownWell!");
                //Main.NewText("DownWell!", Color.Red);
                //tasks.RemoveAll(genpass => !genpass.Name.Equals("Reset"));
                tasks.Add(new PassLegacy("CleanUp", delegate (GenerationProgress progress, GameConfiguration configuration)
                {
                    for(int i = 0; i < Main.maxTilesX; i++)
                    {
                        for(int j = 0; j < Main.maxTilesY; j++)
                        {
                            //WorldGen.KillTile(i, j, noItem: true);
                            Main.tile[i, j].ClearEverything();
                        }
                    }
                }));
                //tasks.Insert(0, new PassLegacy("DownWell", delegate (GenerationProgress progress, GameConfiguration configuration)
                //{
                //    int posleftx = Main.spawnTileX - 15;
                //    int poslefty = Main.spawnTileY;
                //    for (int offsetx = 0; offsetx < 30; offsetx++)
                //    {
                //        WorldGen.PlaceTile(posleftx - offsetx, poslefty, TileID.Dirt);
                //    }

                //}));

            }
            base.ModifyWorldGenTasks(tasks, ref totalWeight);
        }

        public override void ModifyScreenPosition()
        {
            //Main.screenPosition.X = Main.spawnTileX * 16 + Main.screenWidth / 2;
            base.ModifyScreenPosition();
        }
        public static void SetupDungeon()
        {

        }
    }
}

