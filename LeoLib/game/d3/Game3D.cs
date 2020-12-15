using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Game3D  
    {
        public Game3D(string gameTitle)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = gameTitle
            };

            // To create a new window, create a class that extends GameWindow, then call Run() on it.
            using (var window = new Window3D(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
