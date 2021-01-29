using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.events
{
    public class EventKeyBoard : StateEvent
    {
        private readonly Keys key;

        public EventKeyBoard(string nextState, Keys aKey) : base(nextState)
        {
            key = aKey;
        }

        public override bool OnCheck(EventContext context)
        {
            return (context.Input.IsKeyDown(key));
        }
    }
}
