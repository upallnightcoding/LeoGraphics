using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.command
{
    class ProgCmdProgram : ProgCmd
    {
        private List<ProgNode> commands = null;

        public ProgCmdProgram() 
            : base("PROGRAM")
        {
            commands = new List<ProgNode>();
        }

        public override ProgNode Construct(Parser script)
        {
            Token eos = script.GetToken();

            ProgNode command = null;

            return (null);
        }
    }
}
