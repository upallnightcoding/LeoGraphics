using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public abstract class Event
    {
        public string NextState { get; set; } = null;

        public abstract bool Check(EventContext context);

        public Event(string aNextState)
        {
            NextState = aNextState;
        }
    }
}
