using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionSetRotate : Action
    {
        private readonly Rotate position = null;

        private bool alreadySet = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionSetRotate(float x, float y, float z = 0.0f)
        {
            position = new Rotate(x, y, z);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime, Transform transform)
        {
            if (!alreadySet)
            {
                alreadySet = true;

                transform.Rotate(position);
            }
        }
    }
}
