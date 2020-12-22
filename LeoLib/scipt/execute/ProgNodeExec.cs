using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    class ProgNodeExec : ProgNode
    {
        private List<ProgNode> nodeList = null;

        public ProgNodeExec()
        {
            nodeList = new List<ProgNode>();
        }

        public void Add(ProgNode node)
        {
            if (node != null)
            {
                nodeList.Add(node);
            }
        }

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            context.SymTable.NewScope();

            foreach(ProgNode node in nodeList)
            {
                node.Evaluate(context);
            }

            context.SymTable.DeleteScope();

            return (null);
        }
    }
}
