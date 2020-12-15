using LeoLib.game.model.asset;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public abstract class Asset
    {
        private Transform transform = null;

        private Mesh mesh = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Asset(Mesh mesh)
        {
            this.transform = new Transform();

            this.mesh = mesh;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void OnLoad()
        {
            mesh.OnLoad();
        }

        public void Render()
        {
            mesh.Render();
        }

        public void BindMesh()
        {
            mesh.BindMesh();
        }

        public void OnUnLoad()
        {
            mesh.OnUnLoad();
        }
       
    }
}
