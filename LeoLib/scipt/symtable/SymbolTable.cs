using LeoLib.scipt.function;
using LeoLib.script;
using LeoLib.script.execute;
using System.Collections.Generic;

namespace LeoLib.scipt.symtable
{
    /// <summary>
    /// Class SymbolTable <br/>
    /// This class contains all declared variables in the current executing <br/>
    /// program session.System level functions are also included in the <br/>
    /// symbol table and are automatically added to the lowest(first) <br/>
    /// scope level.<br/>
    /// <br/>
    /// Variables are stored in a scope and scopes are stored in a stack.  <br/>
    /// Variables are searched for in the stack from top to bottom.  The <br/>
    /// first instance of the variable found is returned in the invoke. <br/>
    /// </summary>
    public class SymbolTable
    {
        // Stack structure used to manage symbol table scope rules
        private Scope[] SymTable = null;

        // Pointer to the current active scope
        private int activeScope = -1;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolTable()
        {
            SymTable = new Scope[Constant.MAX_SYMBOL_TABLE_SCOPE];

            // Create new scope for this symbol table
            //---------------------------------------
            NewScope();

            // Declare System Functions
            //-------------------------
            Declare(new SysFuncMaxi());
            Declare(new SysFuncRound());
            Declare(new SysFuncNot());
            Declare(new SysFuncSubStr());
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// NewScope() - Create a new scope level for local variables.  Any <br/>
        /// new variables created are declared within the new scope.  The <br/>
        /// new scope is placed on top of the stack and popped when the <br/>
        /// scope is closed.
        /// </summary>
        public void NewScope()
        {
            SymTable[++activeScope] = new Scope();
        }

        /// <summary>
        /// DeleteScope() - Removes a scope object from the top of the scope <br/>
        /// stack.  This is done when executing when a scope has ended during <br/>
        /// execution.
        /// </summary>
        public void DeleteScope()
        {
            // Null the top of the stack when popping
            SymTable[activeScope--] = null;
        }

        public void Declare(string variable, SymbolTableRecType type, int size, ProgNodeValue initialize)
        {
            SymTable[activeScope].Declare(variable, type, size, initialize);
        }

        /// <summary>
        /// Declare() - Declares a system level function and adds it to the <br/>
        /// symbol table at the current scope. 
        /// </summary>
        /// <param name="function"></param>
        public void Declare(SysFunc function)
        {
            SymTable[activeScope].Declare(function);
        }

        /// <summary>
        /// GetSymbolTableRec() - Starts at the top of the stack and searches <br/>
        /// for the first instance of the target variable within the scope.  <br/>
        /// If the variable is found a symbol table records is returned.  If <br/>
        /// the variable is not found a null is returned.  
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public SymbolTableRec GetSymbolTableRec(string variable)
        {
            int scope = activeScope;
            SymbolTableRec symTableRec = SymTable[scope].GetSymbolTableRec(variable);

            while ((symTableRec == null) && (--scope >= 0))
            {
                symTableRec = SymTable[scope].GetSymbolTableRec(variable);
            }

            return (symTableRec);
        }

        public void Assign(string variable, ProgNodeValue value, int index)
        {
            SymbolTableRec record = GetSymbolTableRec(variable);

            if (record != null)
            {
                record.Assign(value, index);
            }
        }

    }
}
