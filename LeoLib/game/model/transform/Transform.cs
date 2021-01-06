using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Transform
    {
        private Scale scale;
        private Rotate rotate;
        private Translate translate;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Transform()
        {
            scale = new Scale();
            rotate = new Rotate();
            translate = new Translate();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Rotate(float x, float y, float z)
        {
            rotate.X = x;
            rotate.Y = y;
            rotate.Z = z;
        }

        public void Translate(float x, float y, float z)
        {
            translate.X = x;
            translate.Y = y;
            translate.Z = z;
        }

        public void Scale(float x, float y, float z)
        {
            scale.X = x;
            scale.Y = y;
            scale.Z = z;
        }

        public void Add(Rotate speed, float deltaTime)
        {
            rotate.X += speed.X * deltaTime;
            rotate.Y += speed.Y * deltaTime;
            rotate.Z += speed.Z * deltaTime;
        }

        public void Add(Translate speed, float deltaTime)
        {
            translate.X += speed.X * deltaTime;
            translate.Y += speed.Y * deltaTime;
            translate.Z += speed.Z * deltaTime;
        }

        public void Add(Scale speed, float deltaTime)
        {
            scale.X += speed.X * deltaTime;
            scale.Y += speed.Y * deltaTime;
            scale.Z += speed.Z * deltaTime;
        }

        public Matrix4 GetModel()
        {
            Matrix4 rotation = rotate.GetRotation();
            Matrix4 translation = translate.GetTranslation();
            Matrix4 scaling = scale.GetScale();

            return (Matrix4.Identity * scaling * rotation * translation);
        }
    }
}
