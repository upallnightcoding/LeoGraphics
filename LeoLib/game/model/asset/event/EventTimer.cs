using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class EventTimer : Event
    {
        public float SleepTimeSec { get; set; } = 0.0f;

        private float accumulate = 0.0f;

        public EventTimer(string nextState, float sleepTimeSec)
        {
            NextState = nextState;
            SleepTimeSec = sleepTimeSec;
        }

        public override bool Check(EventContext context)
        {
            accumulate += context.DeltaTime;

            bool halt = accumulate > SleepTimeSec;
            Console.WriteLine(halt + ":" + accumulate + ":" + SleepTimeSec);

            if (halt)
            {
                accumulate = 0.0f;
            }

            return (halt);
        }
    }
}
