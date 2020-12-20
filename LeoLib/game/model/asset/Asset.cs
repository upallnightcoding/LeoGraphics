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

        private float r = 0.0f;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Asset(Mesh mesh)
        {
            this.transform = new Transform();

            this.mesh = mesh;
        }

        public abstract void AssignTextures();

        public abstract void DeleteTextures();

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime)
        {
            r += deltaTime;
            Rotate(0.0f, 0.0f, 360*r);
            //Translate(deltaTime / 100, 0.0f, 0.0f);
            //Scale(deltaTime / 1000, 1.0f, 1.0f);
        }

        public void Construct()
        {
            mesh.Contruct();
        }

        public void Render()
        {
            AssignTextures();
            //BindVao();
            mesh.Render();
        }

        public void OnUnLoad()
        {
            mesh.OnUnLoad();
            DeleteTextures();
        }

        public Matrix4 GetModel()
        {
            return (transform.GetModel());
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        public void BindVao()
        {
            mesh.BindVao();
        }

        private void Rotate(float x, float y, float z)
        {
            transform.Rotate(x, y, z);
        }

        public void Translate(float x, float y, float z)
        {
            transform.Translate(x, y, z);
        }

        private void Scale(float x, float y, float z)
        {
            transform.Scale(x, y, z);
        }
    }
}
