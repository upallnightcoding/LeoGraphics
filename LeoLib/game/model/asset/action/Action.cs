﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    public interface Action
    {
        public void Update(float deltaTime, Transform transform);
    }
}
