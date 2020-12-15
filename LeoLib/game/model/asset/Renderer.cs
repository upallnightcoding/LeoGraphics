using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public abstract class Renderer
    {
        public abstract void Render(float[] vertices, uint[] indices);
    }
}
