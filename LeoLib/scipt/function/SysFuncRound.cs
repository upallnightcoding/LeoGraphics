using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.function
{
    class SysFuncRound : SysFunc
    {
        public SysFuncRound() 
            : base("round", SymbolTableRecType.INTEGER)
        {

        }

        public override ProgNodeValue Evaluate(ProgNodeContext context, ArgList arguments)
        {
            float value = arguments.GetFloat(context, 0);

            return (new ProgNodeValue((int)(value + 0.5)));
        }
    }
}
