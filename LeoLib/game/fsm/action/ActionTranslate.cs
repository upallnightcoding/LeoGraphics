using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionTranslate : StateAction
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

        public void OnUpdate(float deltaTime, Transform transform)
        {
            transform.Add(speed, deltaTime);
        }
    }
}
