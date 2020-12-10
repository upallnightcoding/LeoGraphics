using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    class SymbolTable
    {
        private Stack<Scope> symTable = null;

        public SymbolTable()
        {
            symTable = new Stack<Scope>();
        }
    }
}
