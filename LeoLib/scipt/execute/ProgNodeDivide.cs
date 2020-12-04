using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    class ProgNodeDivide : ProgNode
    {
        private ProgNode leftExp = null;
        private ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeDivide(ProgNode leftExp, ProgNode rightExp)
        {
            this.leftExp = leftExp;
            this.rightExp = rightExp;
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate()
        {
            ProgNodeValue result = null;

            ProgNodeValue left = leftExp.Evaluate();
            ProgNodeValue right = rightExp.Evaluate();

            switch (left.Type)
            {
                case ProgNodeValueType.FLOAT:
                    float fvalue = left.GetFloat() / right.GetFloat();
                    result = new ProgNodeValue(fvalue);
                    break;
                case ProgNodeValueType.INTEGER:
                    int ivalue = left.GetInteger() / right.GetInteger();
                    result = new ProgNodeValue(ivalue);
                    break;
                case ProgNodeValueType.STRING:
                    string svalue = left.GetString() + right.GetString();
                    result = new ProgNodeValue(svalue);
                    break;
                case ProgNodeValueType.BOOLEAN:
                    bool bvalue = left.GetBool() && right.GetBool();
                    result = new ProgNodeValue(bvalue);
                    break;
            }

            return (result);
        }
    }
}
