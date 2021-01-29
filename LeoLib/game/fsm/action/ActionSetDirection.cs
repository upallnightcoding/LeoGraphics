using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionSetDirection : StateAction
    {
        private readonly Vector3 direction;

        private bool alreadySet = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionSetDirection(float x, float y, float z = 0.0f)
        {
            direction = new Vector3(x, y, z);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void OnUpdate(float deltaTime, Transform transform)
        {
            if (!alreadySet)
            {
                alreadySet = true;

                transform.Direction = direction;
            }
        }
    }
}
