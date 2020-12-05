using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    class Mesh
    {
        public Data data = null;
        public Renderer renderer = null;
        public Assembly assembly = null;

        public Mesh(Data data, Renderer renderer, Assembly assembly)
        {
            this.data = data;
            this.renderer = renderer;
            this.assembly = assembly;
        }
    }
}
