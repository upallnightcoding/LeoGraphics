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
            const string SPIN_STATE = "Spin";
            const float delta = (float)(-360.0f * Math.PI / 180.0);

            State spinState = new State(SPIN_STATE);
            spinState.Add(new ActionSpin(0.0f, 0.0f, -delta * 0.1f));

            Behavior behavior = new Behavior();
            behavior.Add(spinState);

            //Sprite sprite = new Sprite(FACE_IMAGE, behavior);
            Sprite sprite = new Sprite(LEVEL1_IMAGE);

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

            Sprite sprite = new Sprite(FACE_IMAGE);
            sprite.Add(behavior);

            Scene2D scene = new Scene2D();
            scene.Add(sprite);

            return (scene);
        }

        public static Scene2D FlipBookTest()
        {
            const string IDLE00_IMAGE = "animation/idleimages/Idle__000.png";
            const string IDLE01_IMAGE = "animation/idleimages/Idle__001.png";
            const string IDLE02_IMAGE = "animation/idleimages/Idle__002.png";
            const string IDLE03_IMAGE = "animation/idleimages/Idle__003.png";
            const string IDLE04_IMAGE = "animation/idleimages/Idle__004.png";
            const string IDLE05_IMAGE = "animation/idleimages/Idle__005.png";
            const string IDLE06_IMAGE = "animation/idleimages/Idle__006.png";
            const string IDLE07_IMAGE = "animation/idleimages/Idle__007.png";
            const string IDLE08_IMAGE = "animation/idleimages/Idle__008.png";
            const string IDLE09_IMAGE = "animation/idleimages/Idle__009.png";

            FlipBook fb = new FlipBook();
            fb.Add(IDLE00_IMAGE);
            fb.Add(IDLE01_IMAGE);
            fb.Add(IDLE02_IMAGE);
            fb.Add(IDLE03_IMAGE);
            fb.Add(IDLE04_IMAGE);
            fb.Add(IDLE05_IMAGE);
            fb.Add(IDLE06_IMAGE);
            fb.Add(IDLE07_IMAGE);
            fb.Add(IDLE08_IMAGE);
            fb.Add(IDLE09_IMAGE);

            Sprite sprite = new Sprite(fb, null);

            Scene2D scene = new Scene2D();
            scene.Add(new Sprite(fb, null));

            return (scene);
        }
    }
}
