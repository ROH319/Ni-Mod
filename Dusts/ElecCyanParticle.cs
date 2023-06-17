using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Renderers;
using ReLogic.Content;

namespace Ni.Dusts
{
    public class ElecCyanParticle : ABasicParticle
    {
        public override void SetBasicInfo(Asset<Texture2D> textureAsset, Rectangle? frame, Vector2 initialVelocity, Vector2 initialLocalPosition)
        {
            Velocity = initialVelocity;
            LocalPosition = initialLocalPosition;
            ShouldBeRemovedFromRenderer = false;
            base.SetBasicInfo(textureAsset, frame, initialVelocity, initialLocalPosition);
        }
        public override void Update(ref ParticleRendererSettings settings)
        {
            base.Update(ref settings);
        }
        public override void Draw(ref ParticleRendererSettings settings, SpriteBatch spritebatch)
        {
            throw new NotImplementedException();
        }

    }
}

