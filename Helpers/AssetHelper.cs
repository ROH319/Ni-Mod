using Microsoft.CodeAnalysis.Host.Mef;
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
        public static string EffectPath = "Ni/Effects/";
        public static string TransparentImg = "Ni/Images/A";

        public static string DeadCellsSoundPath = SoundPath + "DeadCells/";
        public static string DungreedSoundPath = SoundPath + "Dungreed/";
        public static string STSSoundPath = SoundPath + "SlayTheSpire/";

        public static string NiflheimPath = ImagePath + "Niflheim/";

        public static Texture2D[] IcicleDestroy = new Texture2D[3];
        public static Texture2D[] Icicle = new Texture2D[10];
        public static Texture2D[] IceSpear = new Texture2D[13];
        public static Texture2D[] IcePillarDestroy = new Texture2D[3];
        public static Texture2D[] IcePillar = new Texture2D[20];
        public static Texture2D[] IceCryStal = new Texture2D[21];
        public static Texture2D[] NiflheimIdle = new Texture2D[6];
        public static Texture2D[] NiflheimEnter = new Texture2D[16];
        public static Texture2D[] NiflheimDie = new Texture2D[30];
        public static Texture2D[] NiflheimAttack = new Texture2D[11];
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
        public static Texture2D TrailShape;
        public static SoundStyle Kakaa;
        public static SoundStyle Katana;
        public static SoundStyle BlockAttack;
        public static SoundStyle ElecWhipShoot;
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
            SetColor = ModContent.Request<Effect>(EffectPath + "SetColor", AssetRequestMode.ImmediateLoad).Value;
            MyColor = ModContent.Request<Effect>(EffectPath + "MyColor", AssetRequestMode.ImmediateLoad).Value;
            Trail = ModContent.Request<Effect>(EffectPath + "Trail", AssetRequestMode.ImmediateLoad).Value;

            #region DeadCells
            ElecWhipShoot = GetSound(DeadCellsSoundPath + "Electricwhip_release1");

            for (int i = 1; i < 5; i++)
            {
                Card_Release[i - 1] = GetSound(DeadCellsSoundPath + $"cards_release{i}");
            }
            Card_Hit = GetSound(DeadCellsSoundPath + "cards_hit");

            WarJavelin_Tp = GetSound(DeadCellsSoundPath + "WarJavelin_Tp");
            WarJavelin_Use = GetSound(DeadCellsSoundPath + "WarJavelin_Use");

            #endregion

            #region Dungreed
            Katana = GetSound(DungreedSoundPath + "Katana");

            LaserBow_Use = GetSound(DungreedSoundPath + "LaserBow_Use");
            LaserBow_Extra = GetSound(DungreedSoundPath + "LaserBow_Extra");
            #endregion

            #region SlayTheSpire
            BlockAttack = GetSound(STSSoundPath + "BlockAtk");
            Kakaa = GetSound(STSSoundPath + "CrowCultist");

            LightningOrb_Channel = GetSound(STSSoundPath + "LightningOrb_Channel");
            LightningOrb_Evoke = GetSound(STSSoundPath + "LightningOrb_Evoke");
            LightningOrb_Passive = GetSound(STSSoundPath + "LightningOrb_Passive");

            FlameBarrier_Evoke = GetSound(STSSoundPath + "FlameBarrier_Evoke");
            FlameBarrier_Graze = GetSound(STSSoundPath + "FireIgnite");
            #endregion


            for(int i = 0; i < 3; i++)
            {
                IcicleDestroy[i] = GetTex(NiflheimPath + $"Icicle/IcicleDestroyFX{i}");
            }
            for(int i = 0; i < 10; i++)
            {
                Icicle[i] = GetTex(NiflheimPath + $"Icicle/Icicle{i}");
            }
            for(int i = 0; i < 13; i++)
            {
                IceSpear[i] = GetTex(NiflheimPath + "IceSpear/IceSpear" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }
            for(int i = 0; i < 3; i++)
            {
                IcePillarDestroy[i] = GetTex(NiflheimPath + $"IcePillar/IcePillarDestroyFX{i}");
            }
            for(int i = 0; i < 20; i++)
            {
                IcePillar[i] = GetTex(NiflheimPath + "IcePillar/IcePillar" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }
            for(int i = 0; i < 21; i++)
            {
                IceCryStal[i] = GetTex(NiflheimPath + "IceCrystal/IceCrystalFX" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }
            for (int i = 0; i < 6; i++)
            {
                NiflheimIdle[i] = GetTex(NiflheimPath + $"TrueNPC/NiflheimIdle{i}");
            }
            for(int i = 0; i < 16; i++)
            {
                NiflheimEnter[i] = GetTex(NiflheimPath + "TrueNPC/NiflheimEnter" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }
            for(int i = 0; i < 30; i++)
            {
                NiflheimDie[i] = GetTex(NiflheimPath + "TrueNPC/NiflheimDie" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }
            for (int i = 0; i < 11; i++) 
            {
                NiflheimAttack[i] = GetTex(NiflheimPath + "TrueNPC/NiflheimAttack" + (i < 10 ? "0" + $"{i}" : $"{i}"));
            }

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
        }

        public static Texture2D GetTex(string path) => ModContent.Request<Texture2D>(path, AssetRequestMode.ImmediateLoad)?.Value;

        public static SoundStyle GetSound(string path) => new SoundStyle(path, SoundType.Sound);
    }
}

