using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionTranslate : Action
    {
        private readonly Translate speed = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionTranslate(float xSpeed, float ySpeed, float zSpeed)
        {
            speed = new Translate(xSpeed, ySpeed, zSpeed);
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
