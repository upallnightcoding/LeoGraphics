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
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            int size = vertices.Length * sizeof(float);
            BufferUsageHint usage = BufferUsageHint.StaticDraw;
            BufferTarget target = BufferTarget.ArrayBuffer;

            GL.BufferData(target, size, vertices, usage);

            // VAO Construction
            //-----------------
            //vao = GL.GenVertexArray();
            //GL. (vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        }

        public override void DeConstruct()
        {

        }
    }
}
