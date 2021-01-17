using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.command
{
    class ProgCmdProgram : ProgCmd
    {
        public ProgCmdProgram() 
            : base("PROGRAM")
        {

        }

        public override ProgNode Interpret(Script script)
        {
            Token eos = script.GetToken();

            ProgNode codeBlock = script.ReadCodeBlock();

            return (codeBlock);
        }
    }
}
