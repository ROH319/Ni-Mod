using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
using Ni;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni.Core
{
    public struct VertexInfo2 : IVertexType
    {
        private static VertexDeclaration _vertexDeclaration = new VertexDeclaration
            (new VertexElement[3]
            {
                new VertexElement(0,VertexElementFormat.Vector2,VertexElementUsage.Position,0),
                new VertexElement(8,VertexElementFormat.Color,VertexElementUsage.Color,0),
                new VertexElement(12,VertexElementFormat.Vector3,VertexElementUsage.TextureCoordinate,0),
            });
        /// <summary>
        /// ����λ�ã��������꣩
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// ���Ƶ���ɫ
        /// </summary>
        public Color Color;
        /// <summary>
        /// ǰ�������������꣬���һ�����Զ����
        /// </summary>
        public Vector3 TexCoord;
        public VertexInfo2(Vector2 position,Vector3 texCoord,Color color)
        {
            Position = position;
            TexCoord = texCoord;
            Color = color;
        }
        public VertexInfo2(Vector2 position,Color color,Vector3 texCoord)
        {
            Position = position;
            TexCoord = texCoord;
            Color = color;
        }
        public VertexDeclaration VertexDeclaration
        {
            get => _vertexDeclaration;
        }
    }
}

