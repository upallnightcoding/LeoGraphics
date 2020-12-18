using LeoLib.game.model.asset;
using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using LeoLib.script;

namespace LeoLib.game.model.objects
{
    class SpriteData : AssetData
    {
        public override float[] VertexData()
        {
            float[] vertices =
            {
            // Position         Texture coordinates
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
            };

            return(vertices);
        }
    
        public override uint[] IndicesData()
        {
            uint[] indices =
            {
                0, 1, 3,
                1, 2, 3
            };

            return (indices);
        }

    }

    class RendererSprite : Renderer
    {
        public override void Render(float[] vertices, uint[] indices)
        {
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }

    class AssemblySprite : Assembly
    {
        public override void Construct(float[] vertices, uint[] indices)
        {
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            int size = vertices.Length * sizeof(float); 
            BufferUsageHint usage = BufferUsageHint.StaticDraw;
            BufferTarget target = BufferTarget.ArrayBuffer;

            GL.BufferData(target, size, vertices, usage);

            Vao = GL.GenVertexArray();
            GL.BindVertexArray(Vao);
            GL.BindBuffer(target, Vao);

            ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        }

        public override void DeConstruct()
        {
            GL.DeleteBuffer(vbo);
            GL.DeleteVertexArray(Vao);
        }
    }

    class MeshSprite : Mesh
    {
        public MeshSprite() 
            : base(new SpriteData(), new RendererSprite(), new AssemblySprite())
        {
        }
    }

    class Sprite : Asset
    {
        private Texture texture1;

        private Texture texture2;

        public Sprite()
            : base(new MeshSprite())
        {

        }

        public override void CreateTextures()
        {
            texture1 = new Texture(Constant.RESOURCE + "face.png");

            texture2 = new Texture(Constant.RESOURCE + "awesomeface.png");
        }
    }
}
