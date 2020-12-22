using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    class Scope
    {
        private Dictionary<string, SymbolTableRec> scope = null;

        public Scope()
        {
            scope = new Dictionary<string, SymbolTableRec>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Declare(string name, SymbolTableRecType type, int size, ProgNodeValue initialize)
        {
            scope.Add(name, new SymbolTableRec(name, type, size, initialize));
        }

        public ProgNodeValue Get(string variable)
        {
            SymbolTableRec record = null;
            ProgNodeValue value = null;

            if (scope.TryGetValue(variable, out record))
            {
                value = record.Get();
            }

            return (value);
        }
    }
}
