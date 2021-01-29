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
        private List<StateAction> actions = null;

        // List of state events
        private List<StateEvent> events = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public State(string name) : this(name, null)
        {
        }

        public State(string name, StateAction action)
        {
            Name = name;

            actions = new List<StateAction>();
            events = new List<StateEvent>();

            if (action != null)
            {
                Add(action);
            }
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Add() - Adds an action to the state object, if the action is null <br/>
        /// it will not be added to the state.
        /// </summary>
        /// <param name="aAction"></param>
        public void Add(StateAction aAction)
        {
            if (aAction != null)
            {
                actions.Add(aAction);
            }
        }

        /// <summary>
        /// Add() - Adds an event to the state object, if the event is null <br/>
        /// it will not be added to the state.
        /// </summary>
        /// <param name="aEvent"></param>
        public void Add(StateEvent aEvent) {

            if (aEvent != null)
            {
                events.Add(aEvent);
            }
        }

        public void Update(float deltaTime, Transform transform)
        {
            foreach (var action in actions)
            {
                action.OnUpdate(deltaTime, transform);
            }
        }

        public string Check(EventContext context)
        {
            int eventRaised = -1;

            for (int i = 0, n = events.Count; (i < n) && (eventRaised == -1); i++)
            {
                if (events[i].OnCheck(context))
                {
                    eventRaised = i;
                }
            }

            return ((eventRaised == -1) ? null : events[eventRaised].NextState);
        }
    }
}
