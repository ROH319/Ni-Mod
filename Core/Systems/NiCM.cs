using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.CameraModifiers;

namespace Ni.Core.Systems
{
    public class NiCamera : PunchCameraModifier
    {
        public int ScreenShake;

        public NiCamera(Vector2 startPosition, Vector2 direction, float strength, float vibrationCyclesPerSecond, int frames, float distanceFalloff = -1, string uniqueIdentity = null) : base(startPosition, direction, strength, vibrationCyclesPerSecond, frames, distanceFalloff, uniqueIdentity)
        {

        }
        //public NiCamera(int screenShake)
        //{
        //    ScreenShake = screenShake;
        //}


        //void ICameraModifier.Update(ref CameraInfo cameraPosition)
        //{
        //    if(ScreenShake > 0)
        //    {
        //        Main.screenPosition += NiUtil.Vector2RandUnit(ScreenShake, 0, MathHelper.ToRadians(360));
        //        ScreenShake--;
        //    }
        //    else
        //    {
        //        ScreenShake = 0;
        //    }
        //}
    }
}

