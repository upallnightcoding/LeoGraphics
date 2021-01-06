using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Rotate
    {
        // X-Axis Rotation
        public float X { get; set; } = 0.0f;

        // Y-Axis Rotation
        public float Y { get; set; } = 0.0f;

        // Z-Axis Rotation
        public float Z { get; set; } = 0.0f;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Rotate()
        {

        }

        public Rotate(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

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
