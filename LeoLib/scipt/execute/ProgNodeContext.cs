using LeoLib.scipt.symtable;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    public class ProgNodeContext
    {
        public SymbolTable SymTable { get; set; } = null;

        public ProgNodeContext()
        {
            this.SymTable = new SymbolTable();
        }
    }
}
