using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game.model.asset
{
    
    public abstract class AssetData
    {
        public abstract float[] VertexData();

        public abstract uint[] IndicesData();
    }
}
