using LeoLib.scipt.boxing;
using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
   

    class ProgNodePlus : ProgNode
    {
        private static BoxingPlus boxing = null;

        private ProgNode leftExp = null;
        private ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodePlus(ProgNode leftExp, ProgNode rightExp)
        {
            this.leftExp    = leftExp;
            this.rightExp   = rightExp;

            if (boxing == null)
            {
                boxing = new BoxingPlus();
            }
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate()
        {
            ProgNodeValue left = leftExp.Evaluate();
            ProgNodeValue right = rightExp.Evaluate();

            ProgNodeValue result = boxing.Evaluate(left, right);

            return (result);
        }
    }
}
