using LeoLib.game.texture;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset.action
{
    public class ActionFlipBook : StateAction
    {
        private FlipBook flipBook = null;

        private Boolean firstUpdate = true;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ActionFlipBook(FlipBook flipBook)
        {
            this.flipBook = flipBook;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void OnUpdate(float deltaTime, Transform transform)
        {
            if (firstUpdate)
            {
                firstUpdate = false;

                TextureData data = flipBook.CreateTextures();

                transform.Scale(1.0f, data.Scale(), 1.0f);
            }

            flipBook.AssignTextures();
        }
    }
}
