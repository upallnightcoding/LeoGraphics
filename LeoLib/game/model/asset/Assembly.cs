using OpenTK.Graphics.OpenGL4;

namespace LeoLib.game.model.asset
{
    public abstract class Assembly
    {
        protected int Vbo { get; set; } = 0;
        protected int Ebo { get; set; } = 0;
        protected int Vao { get; set; } = 0;

        public abstract void Construct(float[] vertices, uint[] indices);
        public abstract void DeConstruct();
        public abstract void Render(float[] vertices, uint[] indices);

        public void BindVao()
        {
            GL.BindVertexArray(Vao);
        }
    }
}
