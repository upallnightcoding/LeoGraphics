using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionSpin : StateAction
    {
        private readonly Rotate speed = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionSpin(float xSpeed, float ySpeed, float zSpeed)
        {
            speed = new Rotate(xSpeed, ySpeed, zSpeed);
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
