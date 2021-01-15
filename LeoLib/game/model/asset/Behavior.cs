using System.Collections.Generic;

namespace LeoLib.game.model.asset
{
    public class Behavior
    {
        private Dictionary<string, State> behavior = null;
        private State activeState = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Behavior()
        {
            behavior = new Dictionary<string, State>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Add(State state)
        {
            behavior.Add(state.Name, state);

            if (activeState == null)
            {
                activeState = state;
            }
        }

        public void Update(float deltaTime, Transform transform)
        {
            activeState.Update(deltaTime, transform);
        }

        public void Check(EventContext context)
        {
            State nextState = null;
            string nextStateName = activeState.Check(context);

            if (nextStateName != null)
            {
                if(behavior.TryGetValue(nextStateName, out nextState))
                {
                    activeState = nextState;
                }

            }
        }
    }
}
