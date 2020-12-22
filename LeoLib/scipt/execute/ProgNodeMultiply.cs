﻿using LeoLib.scipt.boxing;
using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    public class ProgNodeMultiply : ProgNode
    {
        private static BoxingMultiply boxing = null;

        private readonly ProgNode leftExp = null;
        private readonly ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeMultiply(ProgNode leftExp, ProgNode rightExp)
        {
            this.leftExp = leftExp;
            this.rightExp = rightExp;

            if (boxing == null)
            {
                boxing = new BoxingMultiply();
            }
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            ProgNodeValue left = leftExp.Evaluate(context);
            ProgNodeValue right = rightExp.Evaluate(context);

            ProgNodeValue result = boxing.Evaluate(left, right);

            return (result);
        }
    }
}
