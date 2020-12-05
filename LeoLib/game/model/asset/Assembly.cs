using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    abstract public class Assembly
    {
        protected int vbo = 0;
        protected int vao = 0;

        public abstract void Construct(float[] vertices);
    }
}
