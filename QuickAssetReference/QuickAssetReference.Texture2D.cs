using ReLogic.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.QuickAssetReference;
public static class ModAssets_Texture2D
{
    public static Asset<Texture2D> iconAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(iconPath);
    public static Asset<Texture2D> iconImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(iconPath, AssetRequestMode.ImmediateLoad);
    public static string iconPath = "icon";
    public static class Buffs
    {
        public static Asset<Texture2D> Buff_144Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Buff_144Path);
        public static Asset<Texture2D> Buff_144ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Buff_144Path, AssetRequestMode.ImmediateLoad);
        public static string Buff_144Path = "Buffs/Buff_144";
        public static Asset<Texture2D> ClockworkCooldownAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ClockworkCooldownPath);
        public static Asset<Texture2D> ClockworkCooldownImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ClockworkCooldownPath, AssetRequestMode.ImmediateLoad);
        public static string ClockworkCooldownPath = "Buffs/ClockworkCooldown";
        public static Asset<Texture2D> ElectronicWhipDebuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectronicWhipDebuffPath);
        public static Asset<Texture2D> ElectronicWhipDebuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectronicWhipDebuffPath, AssetRequestMode.ImmediateLoad);
        public static string ElectronicWhipDebuffPath = "Buffs/ElectronicWhipDebuff";
        public static Asset<Texture2D> EliteTauntedAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteTauntedPath);
        public static Asset<Texture2D> EliteTauntedImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteTauntedPath, AssetRequestMode.ImmediateLoad);
        public static string EliteTauntedPath = "Buffs/EliteTaunted";
        public static Asset<Texture2D> EmotionChipBuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmotionChipBuffPath);
        public static Asset<Texture2D> EmotionChipBuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmotionChipBuffPath, AssetRequestMode.ImmediateLoad);
        public static string EmotionChipBuffPath = "Buffs/EmotionChipBuff";
        public static Asset<Texture2D> FlameBarrierBuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameBarrierBuffPath);
        public static Asset<Texture2D> FlameBarrierBuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameBarrierBuffPath, AssetRequestMode.ImmediateLoad);
        public static string FlameBarrierBuffPath = "Buffs/FlameBarrierBuff";
        public static Asset<Texture2D> FlameCooldownDebuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameCooldownDebuffPath);
        public static Asset<Texture2D> FlameCooldownDebuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameCooldownDebuffPath, AssetRequestMode.ImmediateLoad);
        public static string FlameCooldownDebuffPath = "Buffs/FlameCooldownDebuff";
        public static Asset<Texture2D> LightningBuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningBuffPath);
        public static Asset<Texture2D> LightningBuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningBuffPath, AssetRequestMode.ImmediateLoad);
        public static string LightningBuffPath = "Buffs/LightningBuff";
        public static Asset<Texture2D> MarbledAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MarbledPath);
        public static Asset<Texture2D> MarbledImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MarbledPath, AssetRequestMode.ImmediateLoad);
        public static string MarbledPath = "Buffs/Marbled";
        public static Asset<Texture2D> PenNibBuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PenNibBuffPath);
        public static Asset<Texture2D> PenNibBuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PenNibBuffPath, AssetRequestMode.ImmediateLoad);
        public static string PenNibBuffPath = "Buffs/PenNibBuff";
        public static Asset<Texture2D> SeeriBuffAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SeeriBuffPath);
        public static Asset<Texture2D> SeeriBuffImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SeeriBuffPath, AssetRequestMode.ImmediateLoad);
        public static string SeeriBuffPath = "Buffs/SeeriBuff";
    }

    public static class Images
    {
        public static Asset<Texture2D> AAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(APath);
        public static Asset<Texture2D> AImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(APath, AssetRequestMode.ImmediateLoad);
        public static string APath = "Images/A";
        public static Asset<Texture2D> BallAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BallPath);
        public static Asset<Texture2D> BallImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BallPath, AssetRequestMode.ImmediateLoad);
        public static string BallPath = "Images/Ball";
        public static Asset<Texture2D> ChainLightning2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ChainLightning2Path);
        public static Asset<Texture2D> ChainLightning2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ChainLightning2Path, AssetRequestMode.ImmediateLoad);
        public static string ChainLightning2Path = "Images/ChainLightning2";
        public static Asset<Texture2D> ChainLightning6Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ChainLightning6Path);
        public static Asset<Texture2D> ChainLightning6ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ChainLightning6Path, AssetRequestMode.ImmediateLoad);
        public static string ChainLightning6Path = "Images/ChainLightning6";
        public static Asset<Texture2D> Color_RedAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_RedPath);
        public static Asset<Texture2D> Color_RedImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_RedPath, AssetRequestMode.ImmediateLoad);
        public static string Color_RedPath = "Images/Color_Red";
        public static Asset<Texture2D> Color_Red_WhiteAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Red_WhitePath);
        public static Asset<Texture2D> Color_Red_WhiteImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Red_WhitePath, AssetRequestMode.ImmediateLoad);
        public static string Color_Red_WhitePath = "Images/Color_Red_White";
        public static Asset<Texture2D> Color_YellowAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_YellowPath);
        public static Asset<Texture2D> Color_YellowImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_YellowPath, AssetRequestMode.ImmediateLoad);
        public static string Color_YellowPath = "Images/Color_Yellow";
        public static Asset<Texture2D> Color_Yellow_OrangeAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Yellow_OrangePath);
        public static Asset<Texture2D> Color_Yellow_OrangeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Yellow_OrangePath, AssetRequestMode.ImmediateLoad);
        public static string Color_Yellow_OrangePath = "Images/Color_Yellow_Orange";
        public static Asset<Texture2D> Color_Yellow_Orange2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Yellow_Orange2Path);
        public static Asset<Texture2D> Color_Yellow_Orange2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Color_Yellow_Orange2Path, AssetRequestMode.ImmediateLoad);
        public static string Color_Yellow_Orange2Path = "Images/Color_Yellow_Orange2";
        public static Asset<Texture2D> ElecDustAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDustPath);
        public static Asset<Texture2D> ElecDustImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDustPath, AssetRequestMode.ImmediateLoad);
        public static string ElecDustPath = "Images/ElecDust";
        public static Asset<Texture2D> ElecDust_YellowAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDust_YellowPath);
        public static Asset<Texture2D> ElecDust_YellowImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDust_YellowPath, AssetRequestMode.ImmediateLoad);
        public static string ElecDust_YellowPath = "Images/ElecDust_Yellow";
        public static Asset<Texture2D> ElecDust_Yellow1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDust_Yellow1Path);
        public static Asset<Texture2D> ElecDust_Yellow1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElecDust_Yellow1Path, AssetRequestMode.ImmediateLoad);
        public static string ElecDust_Yellow1Path = "Images/ElecDust_Yellow1";
        public static Asset<Texture2D> Electric_AreaAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Electric_AreaPath);
        public static Asset<Texture2D> Electric_AreaImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Electric_AreaPath, AssetRequestMode.ImmediateLoad);
        public static string Electric_AreaPath = "Images/Electric_Area";
        public static Asset<Texture2D> EliteBarBorderAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarBorderPath);
        public static Asset<Texture2D> EliteBarBorderImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarBorderPath, AssetRequestMode.ImmediateLoad);
        public static string EliteBarBorderPath = "Images/EliteBarBorder";
        public static Asset<Texture2D> EliteBarFillAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarFillPath);
        public static Asset<Texture2D> EliteBarFillImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarFillPath, AssetRequestMode.ImmediateLoad);
        public static string EliteBarFillPath = "Images/EliteBarFill";
        public static Asset<Texture2D> EliteBarGrowAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarGrowPath);
        public static Asset<Texture2D> EliteBarGrowImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EliteBarGrowPath, AssetRequestMode.ImmediateLoad);
        public static string EliteBarGrowPath = "Images/EliteBarGrow";
        public static Asset<Texture2D> Extra_156Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_156Path);
        public static Asset<Texture2D> Extra_156ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_156Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_156Path = "Images/Extra_156";
        public static Asset<Texture2D> Extra_180Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_180Path);
        public static Asset<Texture2D> Extra_180ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_180Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_180Path = "Images/Extra_180";
        public static Asset<Texture2D> Extra_189Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_189Path);
        public static Asset<Texture2D> Extra_189ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_189Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_189Path = "Images/Extra_189";
        public static Asset<Texture2D> Extra_191Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_191Path);
        public static Asset<Texture2D> Extra_191ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_191Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_191Path = "Images/Extra_191";
        public static Asset<Texture2D> Extra_192Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_192Path);
        public static Asset<Texture2D> Extra_192ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_192Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_192Path = "Images/Extra_192";
        public static Asset<Texture2D> Extra_194Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_194Path);
        public static Asset<Texture2D> Extra_194ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_194Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_194Path = "Images/Extra_194";
        public static Asset<Texture2D> Extra_196Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_196Path);
        public static Asset<Texture2D> Extra_196ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_196Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_196Path = "Images/Extra_196";
        public static Asset<Texture2D> Extra_197Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_197Path);
        public static Asset<Texture2D> Extra_197ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_197Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_197Path = "Images/Extra_197";
        public static Asset<Texture2D> Extra_49Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_49Path);
        public static Asset<Texture2D> Extra_49ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_49Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_49Path = "Images/Extra_49";
        public static Asset<Texture2D> Extra_98Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_98Path);
        public static Asset<Texture2D> Extra_98ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Extra_98Path, AssetRequestMode.ImmediateLoad);
        public static string Extra_98Path = "Images/Extra_98";
        public static Asset<Texture2D> FlameRingAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameRingPath);
        public static Asset<Texture2D> FlameRingImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameRingPath, AssetRequestMode.ImmediateLoad);
        public static string FlameRingPath = "Images/FlameRing";
        public static Asset<Texture2D> FX3_gradient_PulseAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FX3_gradient_PulsePath);
        public static Asset<Texture2D> FX3_gradient_PulseImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FX3_gradient_PulsePath, AssetRequestMode.ImmediateLoad);
        public static string FX3_gradient_PulsePath = "Images/FX3_gradient_Pulse";
        public static Asset<Texture2D> heatmapAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(heatmapPath);
        public static Asset<Texture2D> heatmapImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(heatmapPath, AssetRequestMode.ImmediateLoad);
        public static string heatmapPath = "Images/heatmap";
        public static Asset<Texture2D> Orb_EvokeAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Orb_EvokePath);
        public static Asset<Texture2D> Orb_EvokeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Orb_EvokePath, AssetRequestMode.ImmediateLoad);
        public static string Orb_EvokePath = "Images/Orb_Evoke";
        public static Asset<Texture2D> proj1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(proj1Path);
        public static Asset<Texture2D> proj1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(proj1Path, AssetRequestMode.ImmediateLoad);
        public static string proj1Path = "Images/proj1";
        public static Asset<Texture2D> WhiteFlashAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WhiteFlashPath);
        public static Asset<Texture2D> WhiteFlashImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WhiteFlashPath, AssetRequestMode.ImmediateLoad);
        public static string WhiteFlashPath = "Images/WhiteFlash";
        public static class DevilGuitar
        {
            public static Asset<Texture2D> DevilElecGuitarAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitarPath);
            public static Asset<Texture2D> DevilElecGuitarImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitarPath, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitarPath = "Images/DevilGuitar/DevilElecGuitar";
            public static Asset<Texture2D> DevilElecGuitar0Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar0Path);
            public static Asset<Texture2D> DevilElecGuitar0ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar0Path, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitar0Path = "Images/DevilGuitar/DevilElecGuitar0";
            public static Asset<Texture2D> DevilElecGuitar1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar1Path);
            public static Asset<Texture2D> DevilElecGuitar1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar1Path, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitar1Path = "Images/DevilGuitar/DevilElecGuitar1";
            public static Asset<Texture2D> DevilElecGuitar2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar2Path);
            public static Asset<Texture2D> DevilElecGuitar2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar2Path, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitar2Path = "Images/DevilGuitar/DevilElecGuitar2";
            public static Asset<Texture2D> DevilElecGuitar3Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar3Path);
            public static Asset<Texture2D> DevilElecGuitar3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar3Path, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitar3Path = "Images/DevilGuitar/DevilElecGuitar3";
            public static Asset<Texture2D> DevilElecGuitar4Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar4Path);
            public static Asset<Texture2D> DevilElecGuitar4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilElecGuitar4Path, AssetRequestMode.ImmediateLoad);
            public static string DevilElecGuitar4Path = "Images/DevilGuitar/DevilElecGuitar4";
            public static Asset<Texture2D> DevilGuitarBullet0Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet0Path);
            public static Asset<Texture2D> DevilGuitarBullet0ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet0Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet0Path = "Images/DevilGuitar/DevilGuitarBullet0";
            public static Asset<Texture2D> DevilGuitarBullet1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet1Path);
            public static Asset<Texture2D> DevilGuitarBullet1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet1Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet1Path = "Images/DevilGuitar/DevilGuitarBullet1";
            public static Asset<Texture2D> DevilGuitarBullet2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet2Path);
            public static Asset<Texture2D> DevilGuitarBullet2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet2Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet2Path = "Images/DevilGuitar/DevilGuitarBullet2";
            public static Asset<Texture2D> DevilGuitarBullet3Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet3Path);
            public static Asset<Texture2D> DevilGuitarBullet3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet3Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet3Path = "Images/DevilGuitar/DevilGuitarBullet3";
            public static Asset<Texture2D> DevilGuitarBullet4Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet4Path);
            public static Asset<Texture2D> DevilGuitarBullet4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet4Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet4Path = "Images/DevilGuitar/DevilGuitarBullet4";
            public static Asset<Texture2D> DevilGuitarBullet5Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet5Path);
            public static Asset<Texture2D> DevilGuitarBullet5ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBullet5Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBullet5Path = "Images/DevilGuitar/DevilGuitarBullet5";
            public static Asset<Texture2D> DevilGuitarBulletFX0Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX0Path);
            public static Asset<Texture2D> DevilGuitarBulletFX0ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX0Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBulletFX0Path = "Images/DevilGuitar/DevilGuitarBulletFX0";
            public static Asset<Texture2D> DevilGuitarBulletFX1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX1Path);
            public static Asset<Texture2D> DevilGuitarBulletFX1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX1Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBulletFX1Path = "Images/DevilGuitar/DevilGuitarBulletFX1";
            public static Asset<Texture2D> DevilGuitarBulletFX2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX2Path);
            public static Asset<Texture2D> DevilGuitarBulletFX2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX2Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBulletFX2Path = "Images/DevilGuitar/DevilGuitarBulletFX2";
            public static Asset<Texture2D> DevilGuitarBulletFX3Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX3Path);
            public static Asset<Texture2D> DevilGuitarBulletFX3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX3Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBulletFX3Path = "Images/DevilGuitar/DevilGuitarBulletFX3";
            public static Asset<Texture2D> DevilGuitarBulletFX4Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX4Path);
            public static Asset<Texture2D> DevilGuitarBulletFX4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DevilGuitarBulletFX4Path, AssetRequestMode.ImmediateLoad);
            public static string DevilGuitarBulletFX4Path = "Images/DevilGuitar/DevilGuitarBulletFX4";
        }

        public static class KatanaSwing
        {
            public static Asset<Texture2D> DashKatanaHUDAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DashKatanaHUDPath);
            public static Asset<Texture2D> DashKatanaHUDImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DashKatanaHUDPath, AssetRequestMode.ImmediateLoad);
            public static string DashKatanaHUDPath = "Images/KatanaSwing/DashKatanaHUD";
            public static Asset<Texture2D> KatanaFlashAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaFlashPath);
            public static Asset<Texture2D> KatanaFlashImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaFlashPath, AssetRequestMode.ImmediateLoad);
            public static string KatanaFlashPath = "Images/KatanaSwing/KatanaFlash";
            public static Asset<Texture2D> KatanaSpeedSwingFX00Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX00Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX00ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX00Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX00Path = "Images/KatanaSwing/KatanaSpeedSwingFX00";
            public static Asset<Texture2D> KatanaSpeedSwingFX01Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX01Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX01ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX01Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX01Path = "Images/KatanaSwing/KatanaSpeedSwingFX01";
            public static Asset<Texture2D> KatanaSpeedSwingFX02Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX02Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX02ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX02Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX02Path = "Images/KatanaSwing/KatanaSpeedSwingFX02";
            public static Asset<Texture2D> KatanaSpeedSwingFX03Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX03Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX03ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX03Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX03Path = "Images/KatanaSwing/KatanaSpeedSwingFX03";
            public static Asset<Texture2D> KatanaSpeedSwingFX04Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX04Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX04ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX04Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX04Path = "Images/KatanaSwing/KatanaSpeedSwingFX04";
            public static Asset<Texture2D> KatanaSpeedSwingFX05Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX05Path);
            public static Asset<Texture2D> KatanaSpeedSwingFX05ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaSpeedSwingFX05Path, AssetRequestMode.ImmediateLoad);
            public static string KatanaSpeedSwingFX05Path = "Images/KatanaSwing/KatanaSpeedSwingFX05";
        }

        public static class LightningOrb
        {
            public static Asset<Texture2D> lightningAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightningPath);
            public static Asset<Texture2D> lightningImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightningPath, AssetRequestMode.ImmediateLoad);
            public static string lightningPath = "Images/LightningOrb/lightning";
            public static Asset<Texture2D> lightning_passive_1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_1Path);
            public static Asset<Texture2D> lightning_passive_1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_1Path, AssetRequestMode.ImmediateLoad);
            public static string lightning_passive_1Path = "Images/LightningOrb/lightning_passive_1";
            public static Asset<Texture2D> lightning_passive_2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_2Path);
            public static Asset<Texture2D> lightning_passive_2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_2Path, AssetRequestMode.ImmediateLoad);
            public static string lightning_passive_2Path = "Images/LightningOrb/lightning_passive_2";
            public static Asset<Texture2D> lightning_passive_3Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_3Path);
            public static Asset<Texture2D> lightning_passive_3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_3Path, AssetRequestMode.ImmediateLoad);
            public static string lightning_passive_3Path = "Images/LightningOrb/lightning_passive_3";
            public static Asset<Texture2D> lightning_passive_4Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_4Path);
            public static Asset<Texture2D> lightning_passive_4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_4Path, AssetRequestMode.ImmediateLoad);
            public static string lightning_passive_4Path = "Images/LightningOrb/lightning_passive_4";
            public static Asset<Texture2D> lightning_passive_5Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_5Path);
            public static Asset<Texture2D> lightning_passive_5ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(lightning_passive_5Path, AssetRequestMode.ImmediateLoad);
            public static string lightning_passive_5Path = "Images/LightningOrb/lightning_passive_5";
            public static Asset<Texture2D> orbAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(orbPath);
            public static Asset<Texture2D> orbImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(orbPath, AssetRequestMode.ImmediateLoad);
            public static string orbPath = "Images/LightningOrb/orb";
        }

        public static class Lightning
        {
            public static Asset<Texture2D> LightningFX00Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX00Path);
            public static Asset<Texture2D> LightningFX00ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX00Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX00Path = "Images/Lightning/LightningFX00";
            public static Asset<Texture2D> LightningFX01Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX01Path);
            public static Asset<Texture2D> LightningFX01ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX01Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX01Path = "Images/Lightning/LightningFX01";
            public static Asset<Texture2D> LightningFX02Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX02Path);
            public static Asset<Texture2D> LightningFX02ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX02Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX02Path = "Images/Lightning/LightningFX02";
            public static Asset<Texture2D> LightningFX04Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX04Path);
            public static Asset<Texture2D> LightningFX04ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX04Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX04Path = "Images/Lightning/LightningFX04";
            public static Asset<Texture2D> LightningFX05Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX05Path);
            public static Asset<Texture2D> LightningFX05ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX05Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX05Path = "Images/Lightning/LightningFX05";
            public static Asset<Texture2D> LightningFX07Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX07Path);
            public static Asset<Texture2D> LightningFX07ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX07Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX07Path = "Images/Lightning/LightningFX07";
            public static Asset<Texture2D> LightningFX09Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX09Path);
            public static Asset<Texture2D> LightningFX09ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningFX09Path, AssetRequestMode.ImmediateLoad);
            public static string LightningFX09Path = "Images/Lightning/LightningFX09";
        }

        public static class Seeri
        {
            public static Asset<Texture2D> Seeri0Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri0Path);
            public static Asset<Texture2D> Seeri0ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri0Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri0Path = "Images/Seeri/Seeri0";
            public static Asset<Texture2D> Seeri1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri1Path);
            public static Asset<Texture2D> Seeri1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri1Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri1Path = "Images/Seeri/Seeri1";
            public static Asset<Texture2D> Seeri2Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri2Path);
            public static Asset<Texture2D> Seeri2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri2Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri2Path = "Images/Seeri/Seeri2";
            public static Asset<Texture2D> Seeri3Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri3Path);
            public static Asset<Texture2D> Seeri3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri3Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri3Path = "Images/Seeri/Seeri3";
            public static Asset<Texture2D> Seeri4Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri4Path);
            public static Asset<Texture2D> Seeri4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri4Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri4Path = "Images/Seeri/Seeri4";
            public static Asset<Texture2D> Seeri5Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri5Path);
            public static Asset<Texture2D> Seeri5ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri5Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri5Path = "Images/Seeri/Seeri5";
            public static Asset<Texture2D> Seeri6Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri6Path);
            public static Asset<Texture2D> Seeri6ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri6Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri6Path = "Images/Seeri/Seeri6";
            public static Asset<Texture2D> Seeri7Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri7Path);
            public static Asset<Texture2D> Seeri7ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(Seeri7Path, AssetRequestMode.ImmediateLoad);
            public static string Seeri7Path = "Images/Seeri/Seeri7";
        }

    }

    public static class Items
    {
        public static class Accessories
        {
            public static Asset<Texture2D> ATCAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ATCPath);
            public static Asset<Texture2D> ATCImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ATCPath, AssetRequestMode.ImmediateLoad);
            public static string ATCPath = "Items/Accessories/ATC";
            public static Asset<Texture2D> BarricadeAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BarricadePath);
            public static Asset<Texture2D> BarricadeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BarricadePath, AssetRequestMode.ImmediateLoad);
            public static string BarricadePath = "Items/Accessories/Barricade";
            public static Asset<Texture2D> BloodCupAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BloodCupPath);
            public static Asset<Texture2D> BloodCupImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BloodCupPath, AssetRequestMode.ImmediateLoad);
            public static string BloodCupPath = "Items/Accessories/BloodCup";
            public static Asset<Texture2D> BrimstoneAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BrimstonePath);
            public static Asset<Texture2D> BrimstoneImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BrimstonePath, AssetRequestMode.ImmediateLoad);
            public static string BrimstonePath = "Items/Accessories/Brimstone";
            public static Asset<Texture2D> ClockworkAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ClockworkPath);
            public static Asset<Texture2D> ClockworkImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ClockworkPath, AssetRequestMode.ImmediateLoad);
            public static string ClockworkPath = "Items/Accessories/Clockwork";
            public static Asset<Texture2D> CultistMaskAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(CultistMaskPath);
            public static Asset<Texture2D> CultistMaskImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(CultistMaskPath, AssetRequestMode.ImmediateLoad);
            public static string CultistMaskPath = "Items/Accessories/CultistMask";
            public static Asset<Texture2D> DeusExMachinaAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DeusExMachinaPath);
            public static Asset<Texture2D> DeusExMachinaImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DeusExMachinaPath, AssetRequestMode.ImmediateLoad);
            public static string DeusExMachinaPath = "Items/Accessories/DeusExMachina";
            public static Asset<Texture2D> EmergencyTriageAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmergencyTriagePath);
            public static Asset<Texture2D> EmergencyTriageImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmergencyTriagePath, AssetRequestMode.ImmediateLoad);
            public static string EmergencyTriagePath = "Items/Accessories/EmergencyTriage";
            public static Asset<Texture2D> EmotionChipAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmotionChipPath);
            public static Asset<Texture2D> EmotionChipImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EmotionChipPath, AssetRequestMode.ImmediateLoad);
            public static string EmotionChipPath = "Items/Accessories/EmotionChip";
            public static Asset<Texture2D> EnvenomAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EnvenomPath);
            public static Asset<Texture2D> EnvenomImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(EnvenomPath, AssetRequestMode.ImmediateLoad);
            public static string EnvenomPath = "Items/Accessories/Envenom";
            public static Asset<Texture2D> FastingAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FastingPath);
            public static Asset<Texture2D> FastingImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FastingPath, AssetRequestMode.ImmediateLoad);
            public static string FastingPath = "Items/Accessories/Fasting";
            public static Asset<Texture2D> FlameBarrierAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameBarrierPath);
            public static Asset<Texture2D> FlameBarrierImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(FlameBarrierPath, AssetRequestMode.ImmediateLoad);
            public static string FlameBarrierPath = "Items/Accessories/FlameBarrier";
            public static Asset<Texture2D> GunWingAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GunWingPath);
            public static Asset<Texture2D> GunWingImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GunWingPath, AssetRequestMode.ImmediateLoad);
            public static string GunWingPath = "Items/Accessories/GunWing";
            public static Asset<Texture2D> HolyWaterAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HolyWaterPath);
            public static Asset<Texture2D> HolyWaterImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HolyWaterPath, AssetRequestMode.ImmediateLoad);
            public static string HolyWaterPath = "Items/Accessories/HolyWater";
            public static Asset<Texture2D> MagicalMagnifyingGlassAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MagicalMagnifyingGlassPath);
            public static Asset<Texture2D> MagicalMagnifyingGlassImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MagicalMagnifyingGlassPath, AssetRequestMode.ImmediateLoad);
            public static string MagicalMagnifyingGlassPath = "Items/Accessories/MagicalMagnifyingGlass";
            public static Asset<Texture2D> MagicFlowerAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MagicFlowerPath);
            public static Asset<Texture2D> MagicFlowerImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MagicFlowerPath, AssetRequestMode.ImmediateLoad);
            public static string MagicFlowerPath = "Items/Accessories/MagicFlower";
            public static Asset<Texture2D> MarblesAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MarblesPath);
            public static Asset<Texture2D> MarblesImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MarblesPath, AssetRequestMode.ImmediateLoad);
            public static string MarblesPath = "Items/Accessories/Marbles";
            public static Asset<Texture2D> NinjaScrollAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(NinjaScrollPath);
            public static Asset<Texture2D> NinjaScrollImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(NinjaScrollPath, AssetRequestMode.ImmediateLoad);
            public static string NinjaScrollPath = "Items/Accessories/NinjaScroll";
            public static Asset<Texture2D> NoMercyAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(NoMercyPath);
            public static Asset<Texture2D> NoMercyImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(NoMercyPath, AssetRequestMode.ImmediateLoad);
            public static string NoMercyPath = "Items/Accessories/NoMercy";
            public static Asset<Texture2D> PaperCraneAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PaperCranePath);
            public static Asset<Texture2D> PaperCraneImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PaperCranePath, AssetRequestMode.ImmediateLoad);
            public static string PaperCranePath = "Items/Accessories/PaperCrane";
            public static Asset<Texture2D> PenNibAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PenNibPath);
            public static Asset<Texture2D> PenNibImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PenNibPath, AssetRequestMode.ImmediateLoad);
            public static string PenNibPath = "Items/Accessories/PenNib";
            public static Asset<Texture2D> PocketwatchAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PocketwatchPath);
            public static Asset<Texture2D> PocketwatchImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PocketwatchPath, AssetRequestMode.ImmediateLoad);
            public static string PocketwatchPath = "Items/Accessories/Pocketwatch";
            public static Asset<Texture2D> RunicCapacitorAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(RunicCapacitorPath);
            public static Asset<Texture2D> RunicCapacitorImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(RunicCapacitorPath, AssetRequestMode.ImmediateLoad);
            public static string RunicCapacitorPath = "Items/Accessories/RunicCapacitor";
            public static Asset<Texture2D> ScatterBulletsAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ScatterBulletsPath);
            public static Asset<Texture2D> ScatterBulletsImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ScatterBulletsPath, AssetRequestMode.ImmediateLoad);
            public static string ScatterBulletsPath = "Items/Accessories/ScatterBullets";
            public static Asset<Texture2D> SeeriAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SeeriPath);
            public static Asset<Texture2D> SeeriImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SeeriPath, AssetRequestMode.ImmediateLoad);
            public static string SeeriPath = "Items/Accessories/Seeri";
            public static Asset<Texture2D> SnakeSkullAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SnakeSkullPath);
            public static Asset<Texture2D> SnakeSkullImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SnakeSkullPath, AssetRequestMode.ImmediateLoad);
            public static string SnakeSkullPath = "Items/Accessories/SnakeSkull";
            public static Asset<Texture2D> TaserAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TaserPath);
            public static Asset<Texture2D> TaserImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TaserPath, AssetRequestMode.ImmediateLoad);
            public static string TaserPath = "Items/Accessories/Taser";
            public static Asset<Texture2D> WBladeAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WBladePath);
            public static Asset<Texture2D> WBladeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WBladePath, AssetRequestMode.ImmediateLoad);
            public static string WBladePath = "Items/Accessories/WBlade";
        }

        public static class Weapons
        {
            public static Asset<Texture2D> arzunaAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(arzunaPath);
            public static Asset<Texture2D> arzunaImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(arzunaPath, AssetRequestMode.ImmediateLoad);
            public static string arzunaPath = "Items/Weapons/arzuna";
            public static Asset<Texture2D> BulletTimeAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BulletTimePath);
            public static Asset<Texture2D> BulletTimeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(BulletTimePath, AssetRequestMode.ImmediateLoad);
            public static string BulletTimePath = "Items/Weapons/BulletTime";
            public static Asset<Texture2D> DashKatanaAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DashKatanaPath);
            public static Asset<Texture2D> DashKatanaImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(DashKatanaPath, AssetRequestMode.ImmediateLoad);
            public static string DashKatanaPath = "Items/Weapons/DashKatana";
            public static Asset<Texture2D> ElectricWhipAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectricWhipPath);
            public static Asset<Texture2D> ElectricWhipImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectricWhipPath, AssetRequestMode.ImmediateLoad);
            public static string ElectricWhipPath = "Items/Weapons/ElectricWhip";
            public static Asset<Texture2D> ElectrodynamicsAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectrodynamicsPath);
            public static Asset<Texture2D> ElectrodynamicsImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ElectrodynamicsPath, AssetRequestMode.ImmediateLoad);
            public static string ElectrodynamicsPath = "Items/Weapons/Electrodynamics";
            public static Asset<Texture2D> GwendolynAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwendolynPath);
            public static Asset<Texture2D> GwendolynImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwendolynPath, AssetRequestMode.ImmediateLoad);
            public static string GwendolynPath = "Items/Weapons/Gwendolyn";
            public static Asset<Texture2D> HecateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecatePath);
            public static Asset<Texture2D> HecateImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecatePath, AssetRequestMode.ImmediateLoad);
            public static string HecatePath = "Items/Weapons/Hecate";
            public static Asset<Texture2D> KillingDeckAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KillingDeckPath);
            public static Asset<Texture2D> KillingDeckImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KillingDeckPath, AssetRequestMode.ImmediateLoad);
            public static string KillingDeckPath = "Items/Weapons/KillingDeck";
            public static Asset<Texture2D> PerilGlyphsAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PerilGlyphsPath);
            public static Asset<Texture2D> PerilGlyphsImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PerilGlyphsPath, AssetRequestMode.ImmediateLoad);
            public static string PerilGlyphsPath = "Items/Weapons/PerilGlyphs";
            public static Asset<Texture2D> SonicCarbineAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SonicCarbinePath);
            public static Asset<Texture2D> SonicCarbineImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(SonicCarbinePath, AssetRequestMode.ImmediateLoad);
            public static string SonicCarbinePath = "Items/Weapons/SonicCarbine";
            public static Asset<Texture2D> ThunderKunaiAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ThunderKunaiPath);
            public static Asset<Texture2D> ThunderKunaiImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ThunderKunaiPath, AssetRequestMode.ImmediateLoad);
            public static string ThunderKunaiPath = "Items/Weapons/ThunderKunai";
            public static Asset<Texture2D> TombstoneAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstonePath);
            public static Asset<Texture2D> TombstoneImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstonePath, AssetRequestMode.ImmediateLoad);
            public static string TombstonePath = "Items/Weapons/Tombstone";
            public static Asset<Texture2D> WarJavelinAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinPath);
            public static Asset<Texture2D> WarJavelinImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinPath, AssetRequestMode.ImmediateLoad);
            public static string WarJavelinPath = "Items/Weapons/WarJavelin";
            public static Asset<Texture2D> 模板剑Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(模板剑Path);
            public static Asset<Texture2D> 模板剑ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(模板剑Path, AssetRequestMode.ImmediateLoad);
            public static string 模板剑Path = "Items/Weapons/模板剑";
        }

    }

    public static class Projectiles
    {
        public static Asset<Texture2D> arzunaProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(arzunaProjPath);
        public static Asset<Texture2D> arzunaProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(arzunaProjPath, AssetRequestMode.ImmediateLoad);
        public static string arzunaProjPath = "Projectiles/arzunaProj";
        public static Asset<Texture2D> CrimsonCircleAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(CrimsonCirclePath);
        public static Asset<Texture2D> CrimsonCircleImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(CrimsonCirclePath, AssetRequestMode.ImmediateLoad);
        public static string CrimsonCirclePath = "Projectiles/CrimsonCircle";
        public static Asset<Texture2D> GwendolynProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwendolynProjPath);
        public static Asset<Texture2D> GwendolynProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwendolynProjPath, AssetRequestMode.ImmediateLoad);
        public static string GwendolynProjPath = "Projectiles/GwendolynProj";
        public static Asset<Texture2D> GwenProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwenProjPath);
        public static Asset<Texture2D> GwenProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(GwenProjPath, AssetRequestMode.ImmediateLoad);
        public static string GwenProjPath = "Projectiles/GwenProj";
        public static Asset<Texture2D> HecateBulletAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecateBulletPath);
        public static Asset<Texture2D> HecateBulletImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecateBulletPath, AssetRequestMode.ImmediateLoad);
        public static string HecateBulletPath = "Projectiles/HecateBullet";
        public static Asset<Texture2D> HecateProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecateProjPath);
        public static Asset<Texture2D> HecateProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(HecateProjPath, AssetRequestMode.ImmediateLoad);
        public static string HecateProjPath = "Projectiles/HecateProj";
        public static Asset<Texture2D> KatanaProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaProjPath);
        public static Asset<Texture2D> KatanaProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KatanaProjPath, AssetRequestMode.ImmediateLoad);
        public static string KatanaProjPath = "Projectiles/KatanaProj";
        public static Asset<Texture2D> KillingDeckProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KillingDeckProjPath);
        public static Asset<Texture2D> KillingDeckProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(KillingDeckProjPath, AssetRequestMode.ImmediateLoad);
        public static string KillingDeckProjPath = "Projectiles/KillingDeckProj";
        public static Asset<Texture2D> LightningProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningProjPath);
        public static Asset<Texture2D> LightningProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningProjPath, AssetRequestMode.ImmediateLoad);
        public static string LightningProjPath = "Projectiles/LightningProj";
        public static Asset<Texture2D> MawOfDeepProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MawOfDeepProjPath);
        public static Asset<Texture2D> MawOfDeepProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(MawOfDeepProjPath, AssetRequestMode.ImmediateLoad);
        public static string MawOfDeepProjPath = "Projectiles/MawOfDeepProj";
        public static Asset<Texture2D> PumpkinAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PumpkinPath);
        public static Asset<Texture2D> PumpkinImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(PumpkinPath, AssetRequestMode.ImmediateLoad);
        public static string PumpkinPath = "Projectiles/Pumpkin";
        public static Asset<Texture2D> ThunderKunaiProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ThunderKunaiProjPath);
        public static Asset<Texture2D> ThunderKunaiProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(ThunderKunaiProjPath, AssetRequestMode.ImmediateLoad);
        public static string ThunderKunaiProjPath = "Projectiles/ThunderKunaiProj";
        public static Asset<Texture2D> TombstoneProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstoneProjPath);
        public static Asset<Texture2D> TombstoneProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstoneProjPath, AssetRequestMode.ImmediateLoad);
        public static string TombstoneProjPath = "Projectiles/TombstoneProj";
        public static Asset<Texture2D> TombstoneProj1Asset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstoneProj1Path);
        public static Asset<Texture2D> TombstoneProj1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(TombstoneProj1Path, AssetRequestMode.ImmediateLoad);
        public static string TombstoneProj1Path = "Projectiles/TombstoneProj1";
        public static Asset<Texture2D> WarJavelinProjAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinProjPath);
        public static Asset<Texture2D> WarJavelinProjImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinProjPath, AssetRequestMode.ImmediateLoad);
        public static string WarJavelinProjPath = "Projectiles/WarJavelinProj";
        public static Asset<Texture2D> WarJavelinProj_GlowAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinProj_GlowPath);
        public static Asset<Texture2D> WarJavelinProj_GlowImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(WarJavelinProj_GlowPath, AssetRequestMode.ImmediateLoad);
        public static string WarJavelinProj_GlowPath = "Projectiles/WarJavelinProj_Glow";
        public static class Minions
        {
            public static Asset<Texture2D> LightningOrbAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningOrbPath);
            public static Asset<Texture2D> LightningOrbImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Texture2D>(LightningOrbPath, AssetRequestMode.ImmediateLoad);
            public static string LightningOrbPath = "Projectiles/Minions/LightningOrb";
        }

    }

}

