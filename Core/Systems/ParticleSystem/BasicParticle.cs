using Microsoft.Xna.Framework.Graphics;
using Ni.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Ni.Core.Systems.ParticleSystem
{
    public abstract class BasicParticle
    {
        public virtual string Texture => GetType().Namespace.Replace(".", "/") + "/" + GetType().Name;
        public Texture2D TextureReal;
        public void Register()
        {
            TextureReal = AssetHelper.GetTex(Texture);
            SetStaticDefaults();
        }

        public BasicParticle(Vector2 position, Vector2 velocity, float rotation, int timeleft, float scale = 1f, float opacity = 1f)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.Rotation = rotation;
            this.Scale = scale;
            this.Opacity = opacity;
            this.Timeleft = timeleft;
        }
        public virtual void SetStaticDefaults() { }
        public virtual void OnSpawn()
        {

        }
        public void BaseUpdate()
        {
            Timeleft--;
            if (Timeleft == 0) Kill();
            Update();
            Position += Velocity;
        }
        public virtual void Update() { }
        public virtual void Draw()
        {
            DrawSelf(Main.spriteBatch);
        }
        public void DrawSelf(SpriteBatch spriteBatch)
        {

        }
        public virtual void OnKill() { }
        public void Kill()
        {
            OnKill();
            ParticleSystem.particles.Remove(this);
        }

        public Vector2 Position = Vector2.Zero;
        public Vector2 Velocity = Vector2.Zero;
        public float Rotation = 0;
        public float Scale = 1f;
        public float Opacity = 1f;
        public int Timeleft = -1;

    }
}
