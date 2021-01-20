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
        const string NINJA_ACTION = "D:\\Application\\cs\\LeoGraphics\\NinjaActions\\";

        const string FACE_IMAGE = "face.png";
        const string LEVEL1_IMAGE = "Level1.png";

        public static Scene2D SpinOffTest()
        {
            const string SPIN_STATE = "Spin";
            const float delta = (float)(-360.0f * Math.PI / 180.0);

            State spinState = new State(SPIN_STATE);
            spinState.Add(new ActionSpin(0.0f, 0.0f, -delta * 0.1f));
            spinState.Add(new ActionTranslate(0.5f));
            spinState.Add(new ActionScale(0.1f, 0.1f, 0.1f));

            Behavior behavior = new Behavior();
            behavior.Add(spinState);

            Sprite sprite = new Sprite(LEVEL1_IMAGE, behavior);

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
            const float FLIP_AMOUNT = (float)(180.0f * Math.PI / 180.0);

            const string FLIP_STATE = "Flip";

            string[] IDLE_IMAGE = new string[]
            {
                NINJA_ACTION + "Idle__000.png",
                NINJA_ACTION + "Idle__001.png",
                NINJA_ACTION + "Idle__002.png",
                NINJA_ACTION + "Idle__003.png",
                NINJA_ACTION + "Idle__004.png",
                NINJA_ACTION + "Idle__005.png",
                NINJA_ACTION + "Idle__006.png",
                NINJA_ACTION + "Idle__007.png",
                NINJA_ACTION + "Idle__008.png",
                NINJA_ACTION + "Idle__009.png"
            };

            string[] JUMP_IMAGE = new string[]
            {
                NINJA_ACTION + "Jump__000.png",
                NINJA_ACTION + "Jump__001.png",
                NINJA_ACTION + "Jump__002.png",
                NINJA_ACTION + "Jump__003.png",
                NINJA_ACTION + "Jump__004.png",
                NINJA_ACTION + "Jump__005.png",
                NINJA_ACTION + "Jump__006.png",
                NINJA_ACTION + "Jump__007.png",
                NINJA_ACTION + "Jump__008.png",
                NINJA_ACTION + "Jump__009.png"
            };

            FlipBook fb = new FlipBook(IDLE_IMAGE);

            State state = new State(FLIP_STATE);
            state.Add(new ActionSetRotate(FLIP_AMOUNT, 0.0f, 0.0f));
            state.Add(new ActionTranslate(0.5f));

            Behavior behavior = new Behavior();
            behavior.Add(state);

            Sprite sprite = new Sprite(fb, behavior);

            Scene2D scene = new Scene2D();
            scene.Add(sprite);

            return (scene);
        }

        public static string[] TestSource_01()
        {
            string[] source = new string[] {
                "program;",
                "  # Testing comments ...",
                "  # Testing comments ...",
                " ",
                "  integer a = 30;",
                "  boolean b = (1 <3); # This is a comment test ...",
                "  print 'Not: ', b, ':', not[b], ':', not[not[b]];",
                "  print 'Maxi: ', maxi[10*a, 20, maxi[10*6, 50+2, 70], 3000];",
                "  print 'Round: ', round[1.7], ':', round[1.2], ':', round[1.9];",
                "  print 'Substr: ', substr['Testing', 0, 4], ':', substr['Testing',3];",
                "  while (a <= 10);",
                "    print a;",
                "    a = a + 2;",
                "  end;",
                "end; # End of program"
            };

            return (source);
        }
    }
}
