using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Transform
    {
        // Defines the scaling factors of a model
        private Scale scale;

        // Defines the axis rotation of a model
        private Rotate rotate;

        // Defines the axis translate of a model
        private Translate translate;

        // Current direction of model
        public Vector3 Direction { get; set; }

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Transform()
        {
            scale = new Scale();
            rotate = new Rotate();
            translate = new Translate();
            Direction = new Vector3(1.0f, 0.0f, 0.0f);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Rotate(Rotate position)
        {
            rotate.X = position.X;
            rotate.Y = position.Y;
            rotate.Z = position.Z;
        }

        public void Translate(Translate position)
        {
            translate.X = position.X;
            translate.Y = position.Y;
            translate.Z = position.Z;
        }

        public void Translate(float x, float y, float z = 0.0f)
        {
            translate.X = x;
            translate.Y = y;
            translate.Z = z;
        }

        public void Scale(float x, float y, float z = 0.0f)
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

        public void Add(float speed, float deltaTime)
        {
            translate.X += speed * Direction.X * deltaTime;
            translate.Y += speed * Direction.Y * deltaTime;
            translate.Z += speed * Direction.Z * deltaTime;
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
