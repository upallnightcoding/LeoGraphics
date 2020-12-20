using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    /// <summary>
    /// This class contains the matrix asset translation capability.  This <br/>
    /// allows an asset to move from one position to another.  The asset <br/>
    /// can move freely on all axises, controlled by the caller.
    /// </summary>
    public class Translate
    {
        // X-Axis Translation
        public float X { get; set; } = 0.0f;

        // Y-Axis Translation
        public float Y { get; set; } = 0.0f;

        // Z-Axis Translation
        public float Z { get; set; } = 0.0f;

        /// <summary>
        /// GetTranslation() - Returns the translation matrix of the current <br/>
        /// asset, used in moving the asset from one position to another.  <br/>
        /// The translation matrix is used by the shader.
        /// </summary>
        /// <returns>Matrix4</returns>
        public Matrix4 GetTranslation()
        {
            return (Matrix4.CreateTranslation(X, Y, Z));
        }
    }
}
