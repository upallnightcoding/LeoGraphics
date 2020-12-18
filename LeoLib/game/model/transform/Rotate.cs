using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Rotate
    {
        private float x = 0.0f;
        private float y = 0.0f;
        private float z = 0.0f;

        public float X {
            get
            {
                return (x);
            }
            set
            {
                x = MathHelper.DegreesToRadians(value);
            }
        }

        public float Y
        {
            get
            {
                return (y);
            }
            set
            {
                y = MathHelper.DegreesToRadians(value);
            }
        }

        public float Z
        {
            get
            {
                return (z);
            }
            set
            {
                z = MathHelper.DegreesToRadians(value);
            }
        }

        public Matrix4 GetRotation()
        {
            Matrix4 r =
                Matrix4.CreateRotationX(x) * 
                Matrix4.CreateRotationY(y) * 
                Matrix4.CreateRotationZ(z);

            return (r);
        }
    }
}
