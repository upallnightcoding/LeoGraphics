using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script.execute
{
    class ProgNodePrint : ProgNode
    {
        private List<ProgNode> arguments = new List<ProgNode>();

        public void Add(ProgNode node)
        {
            if (node != null)
            {
                arguments.Add(node);
            }
        }
    }
}
