using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Rotate
    {
        public float X { get; set; } = 0.0f;
        public float Y { get; set; } = 0.0f;
        public float Z { get; set; } = 0.0f;

        public Rotate()
        {

        }

        public Rotate(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Matrix4 GetRotation()
        {
            Matrix4 rotate =
                Matrix4.CreateRotationX(X) * 
                Matrix4.CreateRotationY(Y) * 
                Matrix4.CreateRotationZ(Z);

            return (rotate);
        }
    }
}
