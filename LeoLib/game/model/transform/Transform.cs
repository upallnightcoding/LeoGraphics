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

        public Transform()
        {
            scale = new Scale();
            rotate = new Rotate();
            translate = new Translate();
        }

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

        public Matrix4 GetModel()
        {
            Matrix4 rotation = rotate.GetRotation();
            Matrix4 translation = translate.GetTranslation();
            Matrix4 scaling = scale.GetScale();

            return (Matrix4.Identity * rotation * translation * scaling);
        }
    }
}
