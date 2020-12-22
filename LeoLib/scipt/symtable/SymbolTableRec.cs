using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    class SymbolTableRec
    {
        public string Name { get; set; } = null;

        private SymbolTableRecType Type { get; set; } = SymbolTableRecType.UNKNOWN;

        private ProgNodeValue[] value = null;

        public SymbolTableRec(string name, SymbolTableRecType type, int size, ProgNodeValue initialize)
        {
            Name = name;
            Type = type;

            value = new ProgNodeValue[size];

            for(int i = 0; i < size; i++)
            {
                value[i] = initialize;
            }
        }

        public ProgNodeValue Get()
        {
            return (value[0]);
        }
    }
}
