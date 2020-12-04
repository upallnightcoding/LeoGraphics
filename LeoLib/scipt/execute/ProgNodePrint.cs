﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script.execute
{
    class ProgNodePrint : ProgNode
    {
        private List<ProgNode> arguments = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodePrint()
        {
            arguments = new List<ProgNode>();
        }

        public void Add(ProgNode node)
        {
            if (node != null)
            {
                arguments.Add(node);
            }
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate()
        {
            foreach(var node in arguments) {
                Console.Write($"{node.Evaluate().GetString()}");
            }

            Console.WriteLine();

            return(null);
        }
    }
}
