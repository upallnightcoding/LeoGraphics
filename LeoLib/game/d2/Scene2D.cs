using LeoLib.game.model.asset;
using LeoLib.game.model.objects;
using LeoLib.script;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.d2
{
    public class Scene2D
    {
        private const string SHADER_UNIFORM_MODEL = Constant.SHADER_UNIFORM_MODEL;

        private List<Sprite> scene = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Scene2D( )
        {
            this.scene = new List<Sprite>();
        }
         
        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime)
        {
            foreach (Sprite sprite in scene)
            {
                sprite.Update(deltaTime);
            }
        }

        public void Check(EventContext context)
        {
            foreach (Sprite sprite in scene)
            {
                sprite.Check(context);
            }
        }

        public void Construct()
        {
            foreach (Sprite sprite in scene)
            {
                sprite.Construct();
            }
        }

        public void Add(Sprite sprite)
        {
            scene.Add(sprite);
        }

        public void Render(Camera camera, Shader shader)
        {
            shader.Use(camera);

            foreach(Sprite sprite in scene) 
            {
                shader.Use(sprite);

                sprite.Render();
            }
        }

        public void OnUnLoad()
        {
            foreach (Sprite sprite in scene)
            {
                sprite.OnUnLoad();
            }
        }
    }
}
