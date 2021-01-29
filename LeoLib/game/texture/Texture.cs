using LeoLib.game.texture;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

namespace LeoLib
{
    public class Texture
    {
        // Class Properties
        //-----------------
        public int Handle { get; set; } = 0;
        public TextureData Data { get; } = null;

        private BitmapData imageData = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Texture(string path)
        {
            Handle = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, Handle);

            using (var bitmap = new Bitmap(path))
            {

                imageData = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb
                );

                //Data = new TextureData(bitmap.Width, bitmap.Height);
                Data = new TextureData(400, 600);

                // Generate a texture using the imageData object
                //----------------------------------------------
                GL.TexImage2D(
                    TextureTarget.Texture2D,
                    0,
                    PixelInternalFormat.Rgba,
                    bitmap.Width,
                    bitmap.Height,
                    0,
                    PixelFormat.Rgba,
                    PixelType.UnsignedByte,
                    imageData.Scan0
                );
            }

            // Set min/mag filter, when texture is scaled.
            //--------------------------------------------
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            // Set wrapping mode for S and T axis
            //-----------------------------------
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            // Generate MipMaps
            //-----------------
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Use()
        {
            //GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Handle);

            /*GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                0,
                0,
                Data.Width,
                Data.Height,
                PixelFormat.Rgba,
                PixelType.UnsignedByte,
                imageData.Scan0);*/
        }
    }
}