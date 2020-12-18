using LeoLib.game.model.objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.d2
{
    class Scene2D
    {
        private List<Sprite> scene = null;

        public Scene2D()
        {
            scene = new List<Sprite>();
        }

        public void add(Sprite sprite)
        {
            scene.Add(sprite);
        }


    }
}
