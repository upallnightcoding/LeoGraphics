using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    class ProgCmdPrint : ProgCmd
    {

        public override ProgNode Parse(Parser script)
        {
            ProgNodePrint command = new ProgNodePrint();

            Token token = script.GetToken();

            if (!token.IsEos())
            {
                while (!token.IsEos()) { 
                    command.Add(new ProgNodeValue(token));

                    token = script.GetToken();

                    if (!token.IsEos())
                    {
                        token = script.GetToken();
                    }
                }
            }

            return (command);
        }
    }
}
