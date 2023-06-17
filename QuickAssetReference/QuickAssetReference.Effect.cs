using ReLogic.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ni.QuickAssetReference;
public static class ModAssets_Effect
{
    public static Asset<Effect> MyColorAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(MyColorPath);
    public static Asset<Effect> MyColorImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(MyColorPath, AssetRequestMode.ImmediateLoad);
    public static string MyColorPath = "Effects/MyColor";
    public static Asset<Effect> SetColorAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(SetColorPath);
    public static Asset<Effect> SetColorImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(SetColorPath, AssetRequestMode.ImmediateLoad);
    public static string SetColorPath = "Effects/SetColor";
    public static Asset<Effect> TrailAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(TrailPath);
    public static Asset<Effect> TrailImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(TrailPath, AssetRequestMode.ImmediateLoad);
    public static string TrailPath = "Effects/Trail";
    public static class XNB编译器v1_1_修复shader语法
    {
        public static class Content
        {
            public static Asset<Effect> MyColorAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(MyColorPath);
            public static Asset<Effect> MyColorImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(MyColorPath, AssetRequestMode.ImmediateLoad);
            public static string MyColorPath = "Effects/XNB编译器v1_1_修复shader语法/Content/MyColor";
            public static Asset<Effect> SetColorAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(SetColorPath);
            public static Asset<Effect> SetColorImmediateAsset => ModAssets_Utils.Mod.Assets.Request<Effect>(SetColorPath, AssetRequestMode.ImmediateLoad);
            public static string SetColorPath = "Effects/XNB编译器v1_1_修复shader语法/Content/SetColor";
        }

    }

}

