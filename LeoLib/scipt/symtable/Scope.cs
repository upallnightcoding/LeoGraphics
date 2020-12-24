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

        public ProgNodeValue GetValue(string variable, int index)
        {
            ProgNodeValue value = null;

            if (scope.TryGetValue(variable, out SymbolTableRec record))
            {
                value = record.GetValue(index);
            }

            return (value);
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
