using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionSpin : Action
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

        public void Update(float deltaTime, Transform transform)
        {
            transform.Add(speed, deltaTime);
        }
    }
}
