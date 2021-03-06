﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionSetRotate : StateAction
    {
        private readonly Rotate position = null;

        private bool firstUpdate = true;

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

        public void OnUpdate(float deltaTime, Transform transform)
        {
            if (firstUpdate)
            {
                firstUpdate = false;

                transform.Rotate(position);
            }
        }
    }
}
