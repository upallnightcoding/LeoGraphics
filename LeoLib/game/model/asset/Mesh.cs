using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class Mesh
    {
        public AssetData data = null;
        public Assembly assembly = null;

        private float[] vertices = null;
        private uint[] indices = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Mesh(AssetData data, Assembly assembly)
        {
            this.data = data;
            this.assembly = assembly;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Contruct()
        {
            vertices = data.VertexData();
            indices = data.IndicesData();

            assembly.Construct(vertices, indices);
        }

        public void BindVao()
        {
            assembly.BindVao();
        }

        public void Render()
        {
            assembly.Render(vertices, indices);
        }

        public void OnUnLoad()
        {
            assembly.DeConstruct();
        }
    }
}
