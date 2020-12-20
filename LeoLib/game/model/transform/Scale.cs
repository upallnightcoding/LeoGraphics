using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Scale
    {
        // X-Axis Scaling
        public float X { get; set; } = 1.0f;

        // Y-Axis Scaling
        public float Y { get; set; } = 1.0f;

        // Z-Axis Scaling
        public float Z { get; set; } = 1.0f;

        public Matrix4 GetScale()
        {
            return (Matrix4.CreateScale(X, Y, Z));
        }
    }
}
