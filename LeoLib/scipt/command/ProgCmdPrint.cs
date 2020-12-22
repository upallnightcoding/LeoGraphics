using LeoLib.scipt;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    class ProgCmdPrint : ProgCmd
    {
        public ProgCmdPrint() : base("PRINT")
        {

        }

        public override ProgNode Interpret(Script script)
        {
            ProgNodePrint command = new ProgNodePrint();

            Token endingToken = new Token();

            while (!endingToken.IsEos())
            {
                ProgNode expression = script.Expression();

                command.Add(expression);

                endingToken = expression.EndingToken;
            }

            return (command);
        }
    }
}
