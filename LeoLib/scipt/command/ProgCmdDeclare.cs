using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.command
{
    class ProgCmdDeclare : ProgCmd
    {
        public SymbolTableRecType Type { get; set; } = SymbolTableRecType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgCmdDeclare(string command, SymbolTableRecType type) : base(command)
        {
            this.Type = type;
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNode Interpret(Script script)
        {
            ProgNodeDeclare command = new ProgNodeDeclare();

            Token varName = new Token();
            Token nextToken = new Token();

            while (!nextToken.IsEos())
            {
                ProgNode expression = null;

                varName = script.GetToken();
                nextToken = script.GetToken();

                if (nextToken.IsAssign())
                {
                    expression = script.Expression();
                    nextToken = expression.EndingToken;
                }

                command.Delcare(varName, Type, new ProgNodeValue(1), expression);
            }

            return (command);
        }
    }
}
