using LeoLib.scipt.execute;
using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.command
{
    /// <summary>
    /// ProgCmdEnd - This class is used to represent the END command.  The <br/>
    /// command is usually used to denote the end of a code block.  Code <br/>
    /// blocks can be formed to execute while loop, if statements and program <br/>
    /// statements.  The END command has no functional purpose than being <br/>
    /// used as a tag.<br/>
    /// 
    /// Command:
    ///     END;
    ///     
    /// </summary>
    class ProgCmdEnd : ProgCmd
    {
        public ProgCmdEnd() 
            : base("END")
        {

        }

        public override ProgNode Construct(Parser script)
        {
            // Skip over the end-of-statement character
            script.GetToken();

            return (new ProgNodeEnd());
        }
    }
}
