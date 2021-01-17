using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.function
{
    class SysFuncNot : SysFunc
    {
        public SysFuncNot()
            : base("not", SymbolTableRecType.BOOLEAN)
        {

        }

        public override ProgNodeValue Evaluate(ProgNodeContext context, ArgList arguments)
        {
            bool value = !arguments.GetBoolean(context, 0);

            return (new ProgNodeValue(value));
        }
    }
}
