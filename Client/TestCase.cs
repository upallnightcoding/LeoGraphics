using LeoLib.game.d2;
using LeoLib.game.model.asset;
using LeoLib.game.model.asset.action;
using LeoLib.game.model.asset.events;
using LeoLib.game.model.objects;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class TestCase
    {
        const string FACE_IMAGE = "face.png";
        const string LEVEL1_IMAGE = "Level1.png";

        public static Scene2D SpinFaceTest()
        {
            Behavior behavior = new Behavior();
            //behavior.Add(new ActionSpin(0.0f, 0.0f, (float)(360.0f * Math.PI / 180.0)));

            Sprite sprite = new Sprite(FACE_IMAGE);
            //sprite.Add();

            Scene2D scene = new Scene2D();
            scene.Add(sprite);

            return (scene);
        }

        public static Scene2D SpinStateTest()
        {
            const string SPIN_CW = "Spin CW";
            const string SPIN_CCW = "Spin CCW";
            const float delta = (float)(-360.0f * Math.PI / 180.0);
            const float waitSeconds = 1.0f;

            State spinCWState = new State(SPIN_CW);
            spinCWState.Add(new ActionSpin(0.0f, 0.0f, -delta));
            spinCWState.Add(new EventTimer(SPIN_CCW, waitSeconds));

            State spinCCWState = new State(SPIN_CCW);
            spinCCWState.Add(new ActionSpin(0.0f, 0.0f, delta));
            spinCCWState.Add(new EventTimer(SPIN_CW, waitSeconds));

            Behavior behavior = new Behavior();
            behavior.Add(spinCWState);
            behavior.Add(spinCCWState);

            Sprite sprite = new Sprite(FACE_IMAGE);
            sprite.Add(behavior);

            Scene2D scene = new Scene2D();
            scene.Add(sprite);

            return (scene);
        }

        public static Scene2D SpinStateKeyBoardTest()
        {
            const string SPIN_CW = "Spin CW";
            const string SPIN_CCW = "Spin CCW";
            const float delta = (float)(-360.0f * Math.PI / 180.0);

            State spinCWState = new State(SPIN_CW);
            spinCWState.Add(new ActionSpin(0.0f, 0.0f, -delta));
            spinCWState.Add(new EventKeyBoard(SPIN_CCW, Keys.D));

            State spinCCWState = new State(SPIN_CCW);
            spinCCWState.Add(new ActionSpin(0.0f, 0.0f, delta));
            spinCCWState.Add(new EventKeyBoard(SPIN_CW, Keys.A));

            Behavior behavior = new Behavior();
            behavior.Add(spinCWState);
            behavior.Add(spinCCWState);

            Sprite sprite = new Sprite(LEVEL1_IMAGE);
            sprite.Add(behavior);

            Scene2D scene = new Scene2D();
            scene.Add(sprite);

            return (scene);
        }
    }
}
