using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public class EventContext
    {
        public Color4 Bg { get; set; } = Color4.BlueViolet;
        public KeyboardState Input { get; set; } = null;

        public float DeltaTime { get; set; } = 0.0f;

        public EventContext()
        {

        }
    }
}
