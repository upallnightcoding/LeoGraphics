using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    class ProgNodeEnd : ProgNode
    {
        public ProgNodeEnd()
        {
            IsEndOfCodeBlock = true;
        }

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            return (null);
        }
    }
}
