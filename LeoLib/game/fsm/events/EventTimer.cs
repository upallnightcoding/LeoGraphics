using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class EventTimer : StateEvent
    {
        public float SleepTimeSec { get; set; } = 0.0f;

        private float accumulate = 0.0f;

        public EventTimer(string nextState, float sleepTimeSec) : base(nextState)
        {
            SleepTimeSec = sleepTimeSec;
        }

        public override bool OnCheck(EventContext context)
        {
            accumulate += context.DeltaTime;

            bool halt = accumulate > SleepTimeSec;

            if (halt)
            {
                accumulate = 0.0f;
            }

            return (halt);
        }
    }
}
