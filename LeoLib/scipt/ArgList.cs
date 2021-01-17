using LeoLib.scipt.execute;
using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt
{
    public class ArgList
    {
        private List<ProgNode> argList = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ArgList()
        {
            argList = new List<ProgNode>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Add(ProgNode argument)
        {
            if (argument != null)
            {
                argList.Add(argument);
            }
        }

        public int Size()
        {
            return (argList.Count);
        }

        public int GetInteger(ProgNodeContext context, int index)
        {
            return (argList[index].Evaluate(context).GetInteger());
        }

        public float GetFloat(ProgNodeContext context, int index)
        {
            return (argList[index].Evaluate(context).GetFloat());
        }

        public bool GetBoolean(ProgNodeContext context, int index)
        {
            return (argList[index].Evaluate(context).GetBoolean());
        }

    }
}
