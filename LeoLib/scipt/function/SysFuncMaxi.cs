using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.function
{
    class SysFuncMaxi : SysFunc
    {
        public SysFuncMaxi()
            : base("maxi", SymbolTableRecType.INTEGER)
        {

        }

        public override ProgNodeValue Evaluate(ProgNodeContext context, ArgList arguments)
        {
            int maxValue = arguments.GetInteger(context, 0);

            for (int i = 1; i < arguments.Size(); i++)
            {
                int value = arguments.GetInteger(context, i);

                maxValue = Math.Max(maxValue, value);
            }

            return (new ProgNodeValue(maxValue));
        }
    }
}
