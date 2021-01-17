using LeoLib.scipt.function;
using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    public class SymbolTableRec
    {
        // Name of the Symbol Table variable
        public string Name { get; set; } = null;

        // Type of the symbol table object
        public SymbolTableRecType Type { get; set; } = SymbolTableRecType.UNKNOWN;

        public SymbolTableRecDesig Designation { get; set; } = SymbolTableRecDesig.UNKNOWN;
        public SysFunc Function { get; set; } = null;

        // Values associated with the symbol table object
        private ProgNodeValue[] values = null;


        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolTableRec(string name, SymbolTableRecType type, int size, ProgNodeValue initialize)
        {
            Name = name;
            Type = type;
            Designation = (size == 1) ? SymbolTableRecDesig.SCALAR : SymbolTableRecDesig.ARRAY;

            values = new ProgNodeValue[size];

            for(int i = 0; i < size; i++)
            {
                values[i] = initialize;
            }
        }

        public SymbolTableRec(SysFunc function)
        {
            Name = function.Name;
            Type = function.Type;
            Designation = SymbolTableRecDesig.FUNCTION;
            Function = function;
        }

        public SymbolTableRec(string name)
        {
            Name = name;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public ProgNodeValue GetValue(int index)
        {
            return (values[index]);
        }

        public void Assign(ProgNodeValue value, int index)
        {
            switch(Type)
            {
                case SymbolTableRecType.INTEGER:
                    values[index] = new ProgNodeValue(value.GetInteger());
                    break;
                case SymbolTableRecType.FLOAT:
                    values[index] = new ProgNodeValue(value.GetFloat());
                    break;
                case SymbolTableRecType.STRING:
                    values[index] = new ProgNodeValue(value.GetString());
                    break;
                case SymbolTableRecType.BOOLEAN:
                    values[index] = new ProgNodeValue(value.GetBoolean());
                    break;
            }
                
        }
    }
}
