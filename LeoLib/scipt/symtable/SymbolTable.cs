using LeoLib.script;
using LeoLib.script.execute;
using System.Collections.Generic;

namespace LeoLib.scipt.symtable
{
    public class SymbolTable
    {
        //private Stack<Scope> SymTable { get; set; } = null;

        private Scope[] SymTable = null;

        private int activeScope = -1;

        public SymbolTable()
        {
            SymTable = new Scope[Constant.MAX_SYMBOL_TABLE_SCOPE];
        }

        public void NewScope()
        {
            SymTable[++activeScope] = new Scope();
        }

        public void DeleteScope()
        {
            --activeScope;
        }

        public void Declare(string variable, SymbolTableRecType type, int size, ProgNodeValue initialize)
        {
            SymTable[activeScope].Declare(variable, type, size, initialize);
        }

        public ProgNodeValue GetValue(string variable, int index)
        {
            return (SymTable[activeScope].GetValue(variable, index));
        }

        public void Assign(string variable, ProgNodeValue value, int index)
        {
            SymTable[activeScope].Assign(variable, value, index); 
        }
    }
}
