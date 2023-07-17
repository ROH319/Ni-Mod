using ReLogic.Content;
using Microsoft.Xna.Framework.Audio;

namespace Ni.QuickAssetReference;
public static class ModAssets_SoundEffect
{
    public static class DeadCells
    {
        public static Asset<SoundEffect> cards_hitAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_hitPath);
        public static Asset<SoundEffect> cards_hitImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_hitPath, AssetRequestMode.ImmediateLoad);
        public static string cards_hitPath = "Sounds/DeadCells/cards_hit";
        public static Asset<SoundEffect> cards_release1Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release1Path);
        public static Asset<SoundEffect> cards_release1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release1Path, AssetRequestMode.ImmediateLoad);
        public static string cards_release1Path = "Sounds/DeadCells/cards_release1";
        public static Asset<SoundEffect> cards_release2Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release2Path);
        public static Asset<SoundEffect> cards_release2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release2Path, AssetRequestMode.ImmediateLoad);
        public static string cards_release2Path = "Sounds/DeadCells/cards_release2";
        public static Asset<SoundEffect> cards_release3Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release3Path);
        public static Asset<SoundEffect> cards_release3ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release3Path, AssetRequestMode.ImmediateLoad);
        public static string cards_release3Path = "Sounds/DeadCells/cards_release3";
        public static Asset<SoundEffect> cards_release4Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release4Path);
        public static Asset<SoundEffect> cards_release4ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(cards_release4Path, AssetRequestMode.ImmediateLoad);
        public static string cards_release4Path = "Sounds/DeadCells/cards_release4";
        public static Asset<SoundEffect> Electricwhip_release1Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(Electricwhip_release1Path);
        public static Asset<SoundEffect> Electricwhip_release1ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(Electricwhip_release1Path, AssetRequestMode.ImmediateLoad);
        public static string Electricwhip_release1Path = "Sounds/DeadCells/Electricwhip_release1";
        public static Asset<SoundEffect> Electricwhip_release2Asset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(Electricwhip_release2Path);
        public static Asset<SoundEffect> Electricwhip_release2ImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(Electricwhip_release2Path, AssetRequestMode.ImmediateLoad);
        public static string Electricwhip_release2Path = "Sounds/DeadCells/Electricwhip_release2";
        public static Asset<SoundEffect> WarJavelin_TpAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(WarJavelin_TpPath);
        public static Asset<SoundEffect> WarJavelin_TpImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(WarJavelin_TpPath, AssetRequestMode.ImmediateLoad);
        public static string WarJavelin_TpPath = "Sounds/DeadCells/WarJavelin_Tp";
        public static Asset<SoundEffect> WarJavelin_UseAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(WarJavelin_UsePath);
        public static Asset<SoundEffect> WarJavelin_UseImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(WarJavelin_UsePath, AssetRequestMode.ImmediateLoad);
        public static string WarJavelin_UsePath = "Sounds/DeadCells/WarJavelin_Use";
    }

    public static class Dungreed
    {
        public static Asset<SoundEffect> FrozenTimeAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FrozenTimePath);
        public static Asset<SoundEffect> FrozenTimeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FrozenTimePath, AssetRequestMode.ImmediateLoad);
        public static string FrozenTimePath = "Sounds/Dungreed/FrozenTime";
    }

    public static class SlayTheSpire
    {
        public static Asset<SoundEffect> BlockAtkAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(BlockAtkPath);
        public static Asset<SoundEffect> BlockAtkImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(BlockAtkPath, AssetRequestMode.ImmediateLoad);
        public static string BlockAtkPath = "Sounds/SlayTheSpire/BlockAtk";
        public static Asset<SoundEffect> CrowCultistAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(CrowCultistPath);
        public static Asset<SoundEffect> CrowCultistImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(CrowCultistPath, AssetRequestMode.ImmediateLoad);
        public static string CrowCultistPath = "Sounds/SlayTheSpire/CrowCultist";
        public static Asset<SoundEffect> DefenseBreakAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(DefenseBreakPath);
        public static Asset<SoundEffect> DefenseBreakImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(DefenseBreakPath, AssetRequestMode.ImmediateLoad);
        public static string DefenseBreakPath = "Sounds/SlayTheSpire/DefenseBreak";
        public static Asset<SoundEffect> FireIgniteAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FireIgnitePath);
        public static Asset<SoundEffect> FireIgniteImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FireIgnitePath, AssetRequestMode.ImmediateLoad);
        public static string FireIgnitePath = "Sounds/SlayTheSpire/FireIgnite";
        public static Asset<SoundEffect> FlameBarrier_EvokeAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FlameBarrier_EvokePath);
        public static Asset<SoundEffect> FlameBarrier_EvokeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(FlameBarrier_EvokePath, AssetRequestMode.ImmediateLoad);
        public static string FlameBarrier_EvokePath = "Sounds/SlayTheSpire/FlameBarrier_Evoke";
        public static Asset<SoundEffect> LightningOrb_ChannelAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_ChannelPath);
        public static Asset<SoundEffect> LightningOrb_ChannelImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_ChannelPath, AssetRequestMode.ImmediateLoad);
        public static string LightningOrb_ChannelPath = "Sounds/SlayTheSpire/LightningOrb_Channel";
        public static Asset<SoundEffect> LightningOrb_EvokeAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_EvokePath);
        public static Asset<SoundEffect> LightningOrb_EvokeImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_EvokePath, AssetRequestMode.ImmediateLoad);
        public static string LightningOrb_EvokePath = "Sounds/SlayTheSpire/LightningOrb_Evoke";
        public static Asset<SoundEffect> LightningOrb_PassiveAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_PassivePath);
        public static Asset<SoundEffect> LightningOrb_PassiveImmediateAsset => ModAssets_Utils.Mod.Assets.Request<SoundEffect>(LightningOrb_PassivePath, AssetRequestMode.ImmediateLoad);
        public static string LightningOrb_PassivePath = "Sounds/SlayTheSpire/LightningOrb_Passive";
    }

}

