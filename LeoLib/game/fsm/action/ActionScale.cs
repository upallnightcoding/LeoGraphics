using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionScale : StateAction
    {
        private readonly Scale speed = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionScale(float xSpeed, float ySpeed, float zSpeed)
        {
            speed = new Scale(xSpeed, ySpeed, zSpeed);
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
