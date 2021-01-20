using LeoLib.scipt.execute;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.function 
{
    class SysFuncSubStr : SysFunc
    {
        public SysFuncSubStr()
            : base("substr", symtable.SymbolTableRecType.STRING)
        {

        }

        public override ProgNodeValue Evaluate(ProgNodeContext context, ArgList arguments)
        {
            string value = arguments.GetString(context, 0);
            int start = arguments.GetInteger(context, 1);

            string substring = null;

            switch(arguments.Size())
            {
                case 2:
                    substring = value.Substring(start);
                    break;
                case 3:
                    int length = arguments.GetInteger(context, 2);
                    substring = value.Substring(start, length);
                    break;
            }

            return (new ProgNodeValue(substring));
        }
    }
}
