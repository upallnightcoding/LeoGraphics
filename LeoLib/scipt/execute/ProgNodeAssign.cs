using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    class ProgNodeAssign : ProgNode
    {
        private string variable = null;
        private ProgNode expression = null;

        public ProgNodeAssign(string variable, ProgNode expression)
        {
            this.variable = variable;
            this.expression = expression;
        }

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            ProgNodeValue value = expression.Evaluate(context);

            context.SymTable.Assign(variable, value, 0);

            return (null);
        }
    }
}
