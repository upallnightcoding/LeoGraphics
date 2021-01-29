using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public abstract class StateEvent
    {
        public string NextState { get; set; } = null;

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        public abstract bool OnCheck(EventContext context);

        /************************/
        /*** Public Functions ***/
        /************************/

        public StateEvent(string aNextState)
        {
            NextState = aNextState;
        }
    }
}
