using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.ModLoader;

namespace Ni.Helpers
{
    public class AssetHelper
    {

        public static string ImagePath = "Ni/Images/";
        public static string SoundPath = "Ni/Sounds/";
        public static string TransparentImg = "Ni/Images/A";
        public static Texture2D KatanaHUD;
        public static Texture2D KatanaFlash;
        public static Texture2D[] KatanaSwing = new Texture2D[6];
        public static Texture2D[] Seeri = new Texture2D[8];
        public static Texture2D LightningOrb;
        public static Texture2D OrbFX;
        public static Texture2D[] LightningPassive = new Texture2D[5];
        public static Texture2D Orb_Evoke;
        public static Texture2D LightningProj;
        public static Texture2D ElecCyan_Dust;
        public static Texture2D WarJavelin_Glow;
        public static Texture2D Laser1;
        public static Texture2D TrailLaser;
        public static Texture2D Lightpoint;
        public static Texture2D ElectricArea;
        public static Texture2D Ball;
        public static Texture2D Heatmap;
        public static Texture2D Color_Red;
        public static Texture2D Color_Red_White;
        public static Texture2D Color_Yellow;
        public static Texture2D Color_Yellow_Orange;
        public static Texture2D Color_Yellow_Orange2;
        public static Texture2D EliteBarBorder;
        public static Texture2D EliteBarFill;
        public static Texture2D EliteBarGrow;
        public static Texture2D CrimsonCircle;
        public static Texture2D MawOfDeepProj;
        public static Texture2D TrailShape;

        public static SoundStyle Kakaa;
        public static SoundStyle Katana;
        public static SoundStyle BlockAttack;
        public static SoundStyle ElecWhipShoot;
        public static SoundStyle KunaiShoot;
        public static SoundStyle[] Card_Release = new SoundStyle[4];
        public static SoundStyle Card_Hit;
        public static SoundStyle LaserBow_Extra;
        public static SoundStyle LaserBow_Use;
        public static SoundStyle WarJavelin_Tp;
        public static SoundStyle WarJavelin_Use;
        public static SoundStyle LightningOrb_Channel;
        public static SoundStyle LightningOrb_Evoke;
        public static SoundStyle LightningOrb_Passive;
        public static SoundStyle FlameBarrier_Evoke;
        public static SoundStyle FlameBarrier_Graze;
        public static Effect SetColor;
        public static Effect MyColor;
        public static Effect Trail;

        public static void LoadAsset()
        {
            SetColor = ModContent.Request<Effect>("Ni/Effects/SetColor", AssetRequestMode.ImmediateLoad).Value;
            MyColor = ModContent.Request<Effect>("Ni/Effects/MyColor", AssetRequestMode.ImmediateLoad).Value;
            Trail = ModContent.Request<Effect>("Ni/Effects/Trail", AssetRequestMode.ImmediateLoad).Value;

            BlockAttack = GetSound(SoundPath + "SOTE_SFX_BlockAtk_v2");
            ElecWhipShoot = GetSound(SoundPath + "weapon_electricwhip_release1");
            KunaiShoot = GetSound(SoundPath + "weapon-sound8");

            Kakaa = GetSound(SoundPath + "STS_VO_CrowCultist_1a");
            Katana = GetSound(SoundPath + "katana");
            
            for(int i = 1;i<5; i++)
            {
                Card_Release[i - 1] = GetSound(SoundPath + $"cards_release{i}");
            }
            Card_Hit = GetSound(SoundPath + "cards_hit");

            LaserBow_Use = GetSound(SoundPath + "LaserBow_Use");
            LaserBow_Extra = GetSound(SoundPath + "LaserBow_Extra");

            WarJavelin_Tp = GetSound(SoundPath + "WarJavelin_Tp");
            WarJavelin_Use = GetSound(SoundPath + "WarJavelin_Use");

            LightningOrb_Channel = GetSound(SoundPath + "LightningOrb_Channel");
            LightningOrb_Evoke = GetSound(SoundPath + "LightningOrb_Evoke");
            LightningOrb_Passive = GetSound(SoundPath + "LightningOrb_Passive");

            FlameBarrier_Evoke = GetSound(SoundPath + "FlameBarrier_Evoke");
            FlameBarrier_Graze = GetSound(SoundPath + "FireIgnite");

            KatanaHUD = GetTex(ImagePath + "KatanaSwing/DashKatanaHUD");
            KatanaFlash = GetTex(ImagePath + "KatanaSwing/KatanaFlash");
            for(int i = 0; i < 6; i++)
            {
                KatanaSwing[i] = GetTex(ImagePath + $"KatanaSwing/KatanaSpeedSwingFX0{i}");
            }
            for (int i = 0; i < 8; i++)
            {
                Seeri[i] = GetTex(ImagePath + $"Seeri/Seeri{i}");
            }

            LightningOrb = GetTex(ImagePath + "LightningOrb/lightning");
            OrbFX = GetTex(ImagePath + "LightningOrb/orb");
            for (int i = 1; i < 6; i++)
            {
                LightningPassive[i - 1] = GetTex(ImagePath + $"LightningOrb/lightning_passive_{i}");
            }
            Orb_Evoke = GetTex(ImagePath + "Orb_Evoke");
            LightningProj = GetTex("Ni/Projectiles/LightningProj");


            ElecCyan_Dust = GetTex(ImagePath + "ElecDust_Yellow");
            WarJavelin_Glow = GetTex("Ni/Projectiles/WarJavelinProj_Glow");
            Laser1 = GetTex(ImagePath + "Extra_197");
            TrailLaser = GetTex(ImagePath + "Extra_196");
            TrailShape = GetTex(ImagePath + "Extra_189");
            Lightpoint = GetTex(ImagePath + "Extra_49");
            ElectricArea = GetTex(ImagePath + "Electric_Area");
            Ball = GetTex(ImagePath + "Ball");
            Heatmap = GetTex(ImagePath + "heatmap");
            Color_Red = GetTex(ImagePath + "Color_Red");
            Color_Red_White = GetTex(ImagePath + "Color_Red_White");
            Color_Yellow = GetTex(ImagePath + "Color_Yellow");
            Color_Yellow_Orange = GetTex(ImagePath + "Color_Yellow_Orange");
            Color_Yellow_Orange2 = GetTex(ImagePath + "Color_Yellow_Orange2");
            EliteBarBorder = GetTex(ImagePath + "EliteBarBorder");
            EliteBarFill = GetTex(ImagePath + "EliteBarFill");
            EliteBarGrow = GetTex(ImagePath + "EliteBarGrow");
            CrimsonCircle = GetTex("Ni/Projectiles/CrimsonCircle");
            MawOfDeepProj = GetTex("Ni/Projectiles/MawOfDeepProj");
        }

        public static void UnloadAsset()
        {
            SetColor = null;

            
            LightningOrb = null;
            OrbFX = null;
            LightningProj = null;
            Laser1 = null;
            TrailShape = null;
            Lightpoint = null;
            ElectricArea = null;
            Ball = null;
            Color_Red = null;
            Color_Red_White = null;
            Color_Yellow = null;
            Color_Yellow_Orange = null;
            Color_Yellow_Orange2 = null;
            EliteBarBorder = null;
            EliteBarFill = null;
            EliteBarGrow = null;
            CrimsonCircle = null;
            MawOfDeepProj = null;
        }

        public static Texture2D GetTex(string path) => ModContent.Request<Texture2D>(path, AssetRequestMode.ImmediateLoad).Value;

        public static SoundStyle GetSound(string path) => new SoundStyle(path, SoundType.Sound);
    }
}

