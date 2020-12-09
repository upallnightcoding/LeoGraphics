using LeoLib.scipt;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public abstract class ProgCmd
    {
        public string CommandName { get; set; } = null;

        public ProgCmd(string command)
        {
            this.CommandName = command;
        }

        abstract public ProgNode Interpret(Script script);
    }
}
