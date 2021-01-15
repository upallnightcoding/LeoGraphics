using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    /// <summary>
    /// This class tracks the translation of an asset.  The translation, <br/>
    /// allows the asset to move from one position to another along the <br/>
    /// x, y, or z axis.  It is one of the three matrix values that are <br/>
    /// used to calculate an assets transform.  
    /// </summary>
    public class Translate
    {
        // X-Axis Translation
        public float X { get; set; } = 0.0f;

        // Y-Axis Translation
        public float Y { get; set; } = 0.0f;

        // Z-Axis Translation
        public float Z { get; set; } = 0.0f;

        public int Level { get; set; } = 0;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Translate()
        {

        }

        public Translate(float x, float y, float z = 0.0f)
        {
            X = x;
            Y = y;
            Z = z;
        }

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
