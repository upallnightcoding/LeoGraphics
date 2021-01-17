using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.function
{
    public abstract class SysFunc
    {
        public string Name { get; set; } = null;
        public SymbolTableRecType Type { get; set; } = SymbolTableRecType.UNKNOWN;

        public SysFunc(string name, SymbolTableRecType type)
        {
            Name = name;
            Type = type;
        }

        public abstract ProgNodeValue Evaluate(ProgNodeContext context, ArgList arguments);
    }
}
