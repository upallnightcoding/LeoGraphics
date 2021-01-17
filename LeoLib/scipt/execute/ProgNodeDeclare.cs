using LeoLib.scipt.symtable;
using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    class ProgNodeDeclare : ProgNode
    {
        class Declaration
        {
            public string Name { get; set; }
            public SymbolTableRecType Type { get; set; }
            public ProgNode Size { get; set; } = null;

            public ProgNode Initialize { get; set; } = null;

            /*******************/
            /*** Constructor ***/
            /*******************/

            public Declaration(string name, SymbolTableRecType type, ProgNode size, ProgNode initialize)
            {
                Name = name;
                Type = type;
                Size = size;
                Initialize = initialize;
            }

            public int GetSize(ProgNodeContext context)
            {
                int size = 1;

                if (Size != null)
                {
                    size = Size.Evaluate(context).GetInteger();
                }

                return (size);
            }

            public ProgNodeValue GetInitialize(ProgNodeContext context)
            {
                ProgNodeValue value = null;

                if (Initialize != null)
                {
                    value = Initialize.Evaluate(context);
                }

                return (value);
            }
        }

        private List<Declaration> variables = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeDeclare()
        {
            variables = new List<Declaration>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Delcare(Token variable, SymbolTableRecType type, ProgNode size, ProgNode initialize)
        {
            string name = variable.GetString();

            variables.Add(new Declaration(name, type, size, initialize));
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            foreach(var variable in variables) 
            {
                int size = variable.GetSize(context);

                ProgNodeValue initialize = variable.GetInitialize(context);

                context.SymTable.Declare(variable.Name, variable.Type, size, initialize);
            }

            return (null);
        }
    }
}
