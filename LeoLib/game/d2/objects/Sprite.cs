using LeoLib.game.model.asset;
using OpenTK.Graphics.OpenGL4;
using LeoLib.script;

namespace LeoLib.game.model.objects
{
    class MeshSprite : Mesh
    {
        class AssemblySprite : Assembly
        {
            public override void Construct(float[] vertices, uint[] indices)
            {
                Vbo = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, Vbo);

                int size = vertices.Length * sizeof(float);
                BufferUsageHint usage = BufferUsageHint.StaticDraw;
                BufferTarget target = BufferTarget.ArrayBuffer;

                GL.BufferData(target, size, vertices, usage);

                Vao = GL.GenVertexArray();
                GL.BindVertexArray(Vao);

                Ebo = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, Ebo);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

                var vertexLocation = 0;
                GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
                GL.EnableVertexAttribArray(vertexLocation);

                var texCoordLocation = 1;
                GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
                GL.EnableVertexAttribArray(texCoordLocation);

                GL.BindVertexArray(0);
            }

            public override void Render(float[] vertices, uint[] indices)
            {
                GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
            }

            public override void DeConstruct()
            {
                GL.DeleteBuffer(Vbo);
                GL.DeleteVertexArray(Vao);
            }
        }

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

                return (vertices);
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

        public MeshSprite() 
            : base(new SpriteData(), new AssemblySprite())
        {
        }
    }

    public class Sprite : Asset
    {
        public string Face { get; set; } = null;
        private Texture texture1;

        private Texture texture2;



        public Sprite(string face)
            : base(new MeshSprite())
        {
            //texture1 = new Texture(Constant.RESOURCE + "face.png");
            //texture2 = new Texture(Constant.RESOURCE + "awesomeface.png");

            Face = face;
        }

        public override void AssignTextures()
        {
            texture1 = new Texture(Constant.RESOURCE + Face);
            texture1.Use(TextureUnit.Texture0);
            //texture2.Use(TextureUnit.Texture1);
        }

        public override void DeleteTextures()
        {
            GL.DeleteTexture(texture1.handle);
            //GL.DeleteTexture(texture2.handle);
        }
    }
}
