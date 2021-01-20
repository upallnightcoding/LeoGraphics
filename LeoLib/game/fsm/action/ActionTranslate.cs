using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionTranslate : Action
    {
        private float speed = 0.0f;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionTranslate(float speed)
        {
            this.speed = speed;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime, Transform transform)
        {
            transform.Add(speed, deltaTime);
        }
    }
}
