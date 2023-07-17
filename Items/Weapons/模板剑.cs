using Microsoft.Xna.Framework;
using Ni.Core;
using Ni.Projectiles;
using Ni.Projectiles.Minions;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Ni.DownWell;
using Terraria.Graphics.CameraModifiers;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Schema;
using Ni.Helpers;
using Ni.NPCs.Bosses.NifelheimBoss;
using Ni.Core.Systems.WorldGeneration;

namespace Ni.Items.Weapons
{
	public class 模板剑 : ModItem
	{
		public delegate bool ShootDelegate(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback);
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("模板剑"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			// Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6f;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TestProj>();
			Item.shootSpeed = 1f;
			Item.noUseGraphic = true;
            Item.noMelee = true;
        }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 tomouse = Main.MouseWorld - player.Center;
			tomouse.Normalize();

            var proj = Projectile.NewProjectileDirect(source, player.Center, Vector2.Zero, 
                ModContent.ProjectileType<TestProj>(), 0, 0f, player.whoAmI, 2);
            //var proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

            //NiCamera nicamera = new NiCamera(30);
            //Main.NewText($"{DownWellWorldGen.DownWellWorld}");
            //if(player.altFunctionUse == 2)
            //{
            //	player.statLife -= 100;
            //}
            //for(int i = 0; i < 4; i++)
            //{
            //	player.GetModPlayer<NiPlayer>().Upgraded[i] = false;
            //}
            //AudioSystem.PlaySound(AssetHelper.SoundPath + "weapon_electricwhip_release1.wav", 1f);
            //var p = Projectile.NewProjectileDirect(source, player.Center, Vector2.Zero, ModContent.ProjectileType<FlameLogicProj>(), 0, 0f, player.whoAmI);
            //for(int i = 0; i < 1000; i++)
            //{
            //	Main.projectile[i].Kill();
            //	Main.projectile[i].active = false;
            //	Main.projectile[i] = null;
            //}
            //Main.projectile[0].whoAmI += 0;
            return false;
		}


		public override bool? UseItem(Player player)
        {
            return base.UseItem(player);
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
	}

	public class TestProj : BaseRotateProj
	{
        public override string Texture => AssetHelper.TransparentImg;
        public override void SetDefaults()
        {
			QuickSD(1, 1, 0, DamageClass.Default, 0f, true, false, -1, timeLeft: 3 * 60);
            base.SetDefaults();
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (ai0 == 0)
            {
                int posleftx = Main.spawnTileX - 10;
                int poslefty = Main.spawnTileY;
                int posrightx = Main.spawnTileX + 10;
                int length = Main.ActiveWorldFileData.WorldSizeY * 2 / 3;


                int[] dx = new int[4] { 0, 0, -1, 1 };
                int[] dy = new int[4] { -1, 1, 0, 0 };

                List<Point> pointsolid = new List<Point>();
                void FindGoodPoint()
                {

                }
                for (int offsetx = 1; offsetx < 20; offsetx++)
                {
                    for (int offsety = 1; offsety < length; offsety++)
                    {
                        Main.tile[posleftx + offsetx, poslefty + offsety].ClearEverything();
                    }
                }
                void GenerateBFS(int x, int y, int direction, float chance, int offsety)
                {
                    Tile curtile = Main.tile[x, y];
                    int randy = Main.rand.Next(offsety);
                    for (int yy = y - randy; yy < y + Main.rand.Next(1, 1 + offsety); yy++)
                    {
                        WorldGen.PlaceTile(x, yy, TileID.PinkDungeonBrick);
                    }
                    if (Main.rand.NextFloat(1f) <= chance)
                    {
                        WorldGen.PlaceTile(x + direction, y, TileID.PinkDungeonBrick);
                        GenerateBFS(x + direction, y, direction, chance * 0.9f, randy);
                    }
                }
                for (int j = poslefty; j < poslefty + length; j++)
                {
                    if (Main.rand.NextBool(15))
                    {
                        j += 5;
                        WorldGen.PlaceTile(posleftx + 1, j, TileID.BlueDungeonBrick);
                        pointsolid.Add(new Point(posleftx + 1, j));
                    }
                }
                for (int j = poslefty; j < poslefty + length; j++)
                {
                    if (Main.rand.NextBool(15))
                    {
                        j += 5;
                        WorldGen.PlaceTile(posrightx - 1, j, TileID.BlueDungeonBrick);
                        pointsolid.Add(new Point(posrightx - 1, j));
                    }
                }
                foreach (Point p in pointsolid)
                {
                    if (p != new Point(0, 0))
                    {
                        GenerateBFS(p.X, p.Y, (p.X == posleftx + 1) ? 1 : -1, 1f, 3);
                    }
                }
                for (int y = poslefty; y < poslefty + length; y++)
                {
                    if (Main.rand.NextBool(6))
                    {
                        y += 5;
                        int x = Main.rand.Next(posleftx + 1, posrightx - 1);
                        int randlength = Main.rand.Next(1, 8);
                        while (randlength > 0)
                        {
                            if (x + randlength >= posrightx) continue;
                            WorldGen.PlaceTile(x + randlength, y, TileID.Platforms);
                            randlength--;
                        }
                    }
                }
            }
            if (ai0 == 1)
            {
                for(int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == ModContent.NPCType<Niflheim>())
                    {
                        Main.npc[i].active = false;
                    }
                }
                //NPC ni = NPC.NewNPCDirect(source, Main.MouseWorld, ModContent.NPCType<Niflheim>(), target: Main.LocalPlayer.whoAmI);
            }
            if(ai0 == 2)
            {
                player.Teleport(NiWorld.ShelterCenter.ToWorldCoordinates());
            }
            base.OnSpawn(source);
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return base.Colliding(projHitbox, targetHitbox);
        }
        public override void AI()
        {
            Projectile.timeLeft = 1;
            player.TryGetModPlayer<DownwellPlayer>(out DownwellPlayer dwplr);
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            base.PostDraw(lightColor);
        }
    }
}