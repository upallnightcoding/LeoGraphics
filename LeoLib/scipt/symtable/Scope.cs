using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    class Scope
    {
        private Dictionary<string, Variable> scope = null;

        public Scope()
        {
            scope = new Dictionary<string, Variable>();
        }
    }
}
