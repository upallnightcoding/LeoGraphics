using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    class ProgCmdPrint : ProgCmd
    {
        public ProgCmdPrint() 
            : base("PRINT")
        {

        }

        public override ProgNode Construct(Parser parser)
        {
            ProgNodePrint command = new ProgNodePrint();

            Token endingToken = new Token();

            while (!endingToken.IsEos())
            {
                ProgNode expression = parser.Expression();

                command.Add(expression);

                endingToken = expression.EndingToken;
            }

            return (command);

            /*Token token = parser.GetToken();

            if (!token.IsEos())
            {
                while (!token.IsEos()) {
                    
                    command.Add(new ProgNodeValue(token));

                    token = parser.GetToken();

                    if (!token.IsEos())
                    {
                        token = parser.GetToken();
                    }
                }
            }

            return (command);*/
        }
    }
}
