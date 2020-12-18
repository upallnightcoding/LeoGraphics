using LeoLib.scipt.boxing;
using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    public class ProgNodeMinus : ProgNode
    {
        private static BoxingMinus boxing = null;

        private readonly ProgNode leftExp = null;
        private readonly ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeMinus(ProgNode leftExp, ProgNode rightExp)
        {
            this.leftExp = leftExp;
            this.rightExp = rightExp;

            if (boxing == null)
            {
                boxing = new BoxingMinus();
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
