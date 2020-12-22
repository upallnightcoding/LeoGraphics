using LeoLib.game.model.asset;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.entity
{
    class AssemblyCube : Assembly
    {

        public override void Construct(float[] vertices, uint[] indices)
        {
            // VBO Construction
            //-----------------
            Vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, Vbo);

            int size = vertices.Length * sizeof(float);
            BufferUsageHint usage = BufferUsageHint.StaticDraw;
            BufferTarget target = BufferTarget.ArrayBuffer;

            GL.BufferData(target, size, vertices, usage);

            // VAO Construction
            //-----------------
            //vao = GL.GenVertexArray();
            //GL. (vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, Vbo);
        }

        public override void DeConstruct()
        {

        }

        public override void Render(float[] vertices, uint[] indices)
        {
            throw new NotImplementedException();
        }
    }
}
