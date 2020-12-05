using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt
{
    public class Script
    {
        public Script(Parser parser)
        {
            parser.GetToken();

            //ProgCmdPrint cmdPrint = new ProgCmdPrint();
            //ProgNode node = cmdPrint.Parse(parser);
            //node.Evaluate();

            Expression(parser);
        }

        public ProgNode Expression(Parser parser)
        {
            ProgNode expression = null;

            Token token = parser.GetToken();

            while (!token.IsEoe())
            {
                token.Print();

                token = parser.GetToken();
            }

            return (expression);
        }
    }
}
