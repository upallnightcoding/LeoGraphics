using LeoLib.game.d2;
using LeoLib.game.model.asset;
using LeoLib.game.model.asset.action;
using LeoLib.game.model.objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.testcases
{
    class PlayerJumpOverChest : Scene2D
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

        public PlayerJumpOverChest()
        {
            Add(CreateChest());
            Add(CreatePlayer());
        }

        private Sprite CreateChest()
        {
            const string CHEST_TEXTURE = "container2.png";
            const string CHEST_PROP = "Chest";

            State state = new State(CHEST_PROP);
            state.Add(new ActionSetDirection(0.5f, 0.0f));

            Behavior behavior = new Behavior();
            behavior.Add(state);

            return (new Sprite(IMAGES_DIR + CHEST_TEXTURE, behavior));
        }

        private Sprite CreatePlayer()
        {
            const string IDLE_PLAYER = "Idle";
            const float FLIP_AMOUNT = (float)(180.0f * Math.PI / 180.0);

            State state = new State(IDLE_PLAYER);
            state.Add(new ActionSetRotate(FLIP_AMOUNT, 0.0f));
            state.Add(new ActionTranslate(1.0f));

            Behavior behavior = new Behavior();
            behavior.Add(state);

            return(new Sprite(new FlipBook(IDLE_IMAGE), behavior));
        }
    }
}
