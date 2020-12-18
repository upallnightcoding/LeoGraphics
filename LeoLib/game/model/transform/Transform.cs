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

        public Matrix4 GetModel()
        {
            return (Matrix4.Identity * rotate.GetRotation());
        }
    }
}
