using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    abstract class ProgCmd
    {
        public string CommandName = null;

        public ProgCmd(string command)
        {
            this.CommandName = command;
        }

        abstract public ProgNode Construct(Parser script);
    }
}
