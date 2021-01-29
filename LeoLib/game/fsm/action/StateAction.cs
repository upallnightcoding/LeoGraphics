using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public interface StateAction
    {
        public void OnUpdate(float deltaTime, Transform transform);
    }
}
