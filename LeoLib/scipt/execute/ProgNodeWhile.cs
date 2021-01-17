using LeoLib.script;
using LeoLib.script.execute;
using System;

namespace LeoLib.scipt.execute
{
    class ProgNodeWhile : ProgNode
    {
        private ProgNode expression = null;
        private ProgNode codeBlock = null;

        public ProgNodeWhile(ProgNode expression, ProgNode codeBlock)
        {
            this.expression = expression;
            this.codeBlock = codeBlock;
        }

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            while(expression.Evaluate(context).GetBoolean())
            {
                codeBlock.Evaluate(context);
            }

            return (null);
        }
    }
}
