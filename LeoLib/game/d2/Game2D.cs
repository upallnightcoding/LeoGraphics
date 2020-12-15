using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game
{
    public class Game2D
    {
        public Game2D(string gameTitle)
        {
            //int width = DisplayDevice.Default.Widthl;
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1920, 1080),
                //IsFullscreen = true,
                Title = "LearnOpenTK - Camera"
            };

            using (var window = new Window2D(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}
