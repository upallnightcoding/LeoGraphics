using LeoLib.game.model.asset;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.fsm.action
{
    class ActionFlipRight : StateAction
    {
        private Boolean firstUpdate = true;

        public void OnUpdate(float deltaTime, Transform transform)
        {
            if (firstUpdate)
            {
                firstUpdate = false;

                //transform.Direction = new Vector3()
            }
        }
    }
}
