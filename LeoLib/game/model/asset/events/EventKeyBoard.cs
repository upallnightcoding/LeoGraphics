using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.events
{
    public class EventKeyBoard : Event
    {
        private readonly Keys key;

        public EventKeyBoard(string nextState, Keys aKey) : base(nextState)
        {
            key = aKey;
        }

        public override bool Check(EventContext context)
        {
            return (context.Input.IsKeyDown(key));
        }
    }
}
