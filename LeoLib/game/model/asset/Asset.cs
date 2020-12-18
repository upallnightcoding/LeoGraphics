using LeoLib.game.model.asset;
using OpenTK.Mathematics;
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

        public abstract void CreateTextures();

        /************************/
        /*** Public Functions ***/
        /************************/

        public Matrix4 GetModel()
        {
            return(transform.GetModel());
        }

        public void Rotate(double x, double y, double z)
        {
            transform.Rotate((float) x, (float) y, (float) z);
        }

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
