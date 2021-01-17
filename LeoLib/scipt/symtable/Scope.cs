using LeoLib.scipt.function;
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

        public void Declare(SysFunc function)
        {
            scope.Add(function.Name, new SymbolTableRec(function));
        }

        public SymbolTableRec GetSymbolTableRec(string variable)
        {
            SymbolTableRec symTableRec = null;

            if (scope.TryGetValue(variable, out SymbolTableRec record))
            {
                symTableRec = record;
            }

            return (symTableRec);
        }

        public void Assign(string variable, ProgNodeValue value, int index)
        {
            if (scope.TryGetValue(variable, out SymbolTableRec record))
            {
                record.Assign(value, index);
            }
        }
    }
}
