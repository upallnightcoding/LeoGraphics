using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    abstract class ProgCmd
    {
        abstract public ProgNode Parse(Script script);
    }
}
