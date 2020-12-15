using OpenTK.Graphics.OpenGL4;

namespace LeoLib.game.model.asset
{
    abstract public class Assembly
    {
        protected int vbo = 0;
        protected int ebo = 0;

        public int VAO { get; set; } = 0;

        public abstract void Construct(float[] vertices, uint[] indices);
        public abstract void DeConstruct();

        public void BindMesh()
        {
            GL.BindVertexArray(VAO);
        }
    }
}
