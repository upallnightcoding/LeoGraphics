using LeoLib.game.d2;
using LeoLib.game.model.asset;
using LeoLib.game.model.asset.action;
using LeoLib.game.model.asset.events;
using LeoLib.game.model.objects;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.testcases
{
    class IdleMoveLeftRight : Scene2D
    {
        const string NINJA_ACTION = "D:\\Application\\cs\\LeoGraphics\\NinjaActions\\";
        const string IMAGES_DIR = "D:\\Application\\cs\\LeoGraphics\\images\\";

        private string[] IDLE_IMAGE = new string[]
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

        private string[] RUN_IMAGE = new string[]
        {
            NINJA_ACTION + "Run__000.png",
            NINJA_ACTION + "Run__001.png",
            NINJA_ACTION + "Run__002.png",
            NINJA_ACTION + "Run__003.png",
            NINJA_ACTION + "Run__004.png",
            NINJA_ACTION + "Run__005.png",
            NINJA_ACTION + "Run__006.png",
            NINJA_ACTION + "Run__007.png",
            NINJA_ACTION + "Run__008.png",
            NINJA_ACTION + "Run__009.png"
        };

        public IdleMoveLeftRight()
        {
            Add(CreatePlayer());
        }

        private Sprite CreatePlayer()
        {
            const float FLIP_AMOUNT = (float)(180.0f * Math.PI / 180.0);
            const string IDLE_STATE = "Idle";
            const string MOVE_LEFT_STATE = "Move Left";
            const string MOVE_RIGHT_STATE = "Move Right";
            const float SPEED = 1.0f;

            // Idle State
            //-----------
            State idleState = new State(IDLE_STATE);
            idleState.Add(new ActionSetRotate(FLIP_AMOUNT, 0.0f));
            idleState.Add(new EventKeyBoard(MOVE_LEFT_STATE, Keys.A));
            idleState.Add(new EventKeyBoard(MOVE_RIGHT_STATE, Keys.D));

            // Left State
            //-----------
            State moveLeftState = new State(MOVE_LEFT_STATE);
            moveLeftState.Add(new ActionTranslate(-SPEED));
            moveLeftState.Add(new EventKeyBoard(MOVE_RIGHT_STATE, Keys.D));

            // Right State
            //------------
            State moveRightState = new State(MOVE_RIGHT_STATE);
            moveRightState.Add(new ActionTranslate(SPEED));
            moveRightState.Add(new EventKeyBoard(MOVE_LEFT_STATE, Keys.A));

            // Behavior
            //---------
            Behavior behavior = new Behavior();
            behavior.Add(idleState);
            behavior.Add(moveLeftState);
            behavior.Add(moveRightState);

            FlipBook flipBook = new FlipBook(IDLE_IMAGE);

            Sprite sprite = new Sprite(flipBook, behavior);

            return (sprite);
        }
    }
}
