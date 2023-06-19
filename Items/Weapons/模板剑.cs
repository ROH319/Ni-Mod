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


            int posleftx = Main.spawnTileX - 10;
            int poslefty = Main.spawnTileY;
            int posrightx = Main.spawnTileX + 10;
            int length = Main.ActiveWorldFileData.WorldSizeY * 2 / 3;

            List<Point> pointsolid = new List<Point>();
            void FindGoodPoint()
            {

            }
            void GenerateBFS(int x,int y, int weight)
            {
                Tile curtile = Main.tile[x, y];
                //int direction = (x == posleftx + 1) ? 1 : -1;
                int[] dx = new int[4] { 0, 0, -1, 1 };
                int[] dy = new int[4] { -1, 1, 0, 0 };
                int up = Main.rand.Next(weight / 2);
                int down = Main.rand.Next(weight - up);
                int side = Main.rand.Next(weight - up - down);
                for(int i = 0; i < 4; i++)
                {
                    int xx = x + dx[i];
                    int yy = y + dy[i];
                    Tile nexttile = Main.tile[xx, yy];
                    if (nexttile.HasTile) continue;
                    WorldGen.PlaceTile(xx, yy, TileID.BlueDungeonBrick);
                    GenerateBFS(xx, yy, (dy[i] == -1 ? up : (dy[i] == 1 ? down : side)));
                }
            }
            for (int j = poslefty; j < poslefty + length; j++)
            {
                if (Main.rand.NextBool(30))
                {
                    WorldGen.PlaceTile(posleftx + 1, j, TileID.BlueDungeonBrick);
                    pointsolid.Add(new Point(posrightx + 1, j));
                }
            }
            for (int j = poslefty; j < poslefty + length; j++)
            {
                if (Main.rand.NextBool(30))
                {
                    WorldGen.PlaceTile(posrightx - 1, j, TileID.BlueDungeonBrick);
                    pointsolid.Add(new Point(posrightx - 1, j));
                }
            }
            foreach(Point p in pointsolid)
            {
                GenerateBFS(p.X, p.Y, Main.rand.Next(8, 18));
            }
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
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return base.Colliding(projHitbox, targetHitbox);
        }
        public override void AI()
        {
            Projectile.timeLeft++;
            player.TryGetModPlayer<DownwellPlayer>(out DownwellPlayer dwplr);
            Rectangle rec = dwplr.TestRect;
            Projectile.position = rec.TopLeft();
            Projectile.width = rec.Width;
            Projectile.height = rec.Height;
            base.AI();
        }
        public override void PostDraw(Color lightColor)
        {
            Utils.DrawRect(sb, Projectile.getRect(), Color.Red);
            base.PostDraw(lightColor);
        }
    }
}