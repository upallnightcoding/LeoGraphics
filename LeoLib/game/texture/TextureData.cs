using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.texture
{
    public class TextureData
    {
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public TextureData(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public float Scale()
        {
            return ((float)Height / Width);
        }
    }
}
