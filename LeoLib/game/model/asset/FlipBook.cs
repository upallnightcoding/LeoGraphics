using LeoLib.script;
using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using System.Text;
using LeoLib.game.texture;

namespace LeoLib.game.model.asset
{

    public class FlipBook
    {
        // Class Constants
        const string RESOURCE = Constant.RESOURCE;

        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public TextureData Data { get; set; } = null;

        // Readonly Variables
        private readonly List<string> paths = null;
        private int textureIndex = 0;

        private Texture[] texture = null;


        /*******************/
        /*** Constructor ***/
        /*******************/

        public FlipBook()
        {
            paths = new List<string>();
        }

        public FlipBook(string path) : this()
        {
            Add(path);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Add(string path)
        {
            paths.Add(path);
        }

        public TextureData CreateTextures()
        {
            texture = new Texture[paths.Count];

            for (int i = 0, n = paths.Count; i < n; i++)
            {
                texture[i] = new Texture(RESOURCE + paths[i]);

                if (i == 0)
                {
                    Data = texture[0].Data;
                }
            }

            return (Data);
        }

        public void AssignTextures()
        {
            //texture[textureIndex].Use(TextureUnit.Texture0 + textureIndex);
            texture[textureIndex].Use(TextureUnit.Texture0);

            textureIndex = (++textureIndex) % paths.Count;
        }

        public void DeleteTextures()
        {
            GL.DeleteTexture(texture[textureIndex].Handle);
        }
    }
}
