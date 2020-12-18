using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class Mesh
    {
        public AssetData data = null;
        public Renderer renderer = null;
        public Assembly assembly = null;

        private float[] vertices = null;
        private uint[] indices = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Mesh(AssetData data, Renderer renderer, Assembly assembly)
        {
            this.data = data;
            this.renderer = renderer;
            this.assembly = assembly;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void OnLoad()
        {
            vertices = data.VertexData();
            indices = data.IndicesData();

            assembly.Construct(vertices, indices);
        }

        public void BindMesh()
        {
            assembly.BindMesh();
        }

        public void Render()
        {
            renderer.Render(vertices, indices);
        }

        public void OnUnLoad()
        {
            assembly.DeConstruct();
        }
    }
}
