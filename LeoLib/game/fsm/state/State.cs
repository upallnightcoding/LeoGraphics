using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class State
    {
        // Name of the state
        public string Name { set; get; } = null;

        // List of state actions
        private List<Action> actions = null;

        private List<Event> events = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public State(string name) : this(name, null)
        {
        }

        public State(string name, Action action)
        {
            Name = name;

            actions = new List<Action>();
            events = new List<Event>();

            if (action != null)
            {
                Add(action);
            }
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Add(Action action)
        {
            if (action != null)
            {
                actions.Add(action);
            }
        }

        public void Add(Event aEvent) {

            if (aEvent != null)
            {
                events.Add(aEvent);
            }
        }

        public void Update(float deltaTime, Transform transform)
        {
            foreach (var action in actions)
            {
                action.Update(deltaTime, transform);
            }
        }

        public string Check(EventContext context)
        {
            int eventRaised = -1;

            for (int i = 0, n = events.Count; (i < n) && (eventRaised == -1); i++)
            {
                if (events[i].Check(context))
                {
                    eventRaised = i;
                }
            }

            return ((eventRaised == -1) ? null : events[eventRaised].NextState);
        }
    }
}
