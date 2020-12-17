using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    public class ProgNodeMinus : script.ProgNode
    {
        private script.ProgNode leftExp = null;
        private script.ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeMinus(script.ProgNode leftExp, script.ProgNode rightExp)
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
                    float fvalue = left.GetFloat() - right.GetFloat();
                    result = new ProgNodeValue(fvalue);
                    break;
                case ProgNodeValueType.INTEGER:
                    int ivalue = left.GetInteger() - right.GetInteger();
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

        public ProgNodeValue xEvaluate()
        {
            ProgNodeValue result = null;

            ProgNodeValue left = leftExp.Evaluate();
            ProgNodeValue right = rightExp.Evaluate();

            switch (left.Type)
            {
                case ProgNodeValueType.FLOAT:
                    switch (right.Type)
                    {
                        case ProgNodeValueType.FLOAT:
                            break;
                        case ProgNodeValueType.INTEGER:
                            break;
                        case ProgNodeValueType.STRING:
                            break;
                        case ProgNodeValueType.BOOLEAN:
                            break;
                    }
                    break;
                case ProgNodeValueType.INTEGER:
                    switch (right.Type)
                    {
                        case ProgNodeValueType.FLOAT:
                            break;
                        case ProgNodeValueType.INTEGER:
                            break;
                        case ProgNodeValueType.STRING:
                            break;
                        case ProgNodeValueType.BOOLEAN:
                            break;
                    }
                    break;
                case ProgNodeValueType.STRING:
                    switch (right.Type)
                    {
                        case ProgNodeValueType.FLOAT:
                            break;
                        case ProgNodeValueType.INTEGER:
                            break;
                        case ProgNodeValueType.STRING:
                            break;
                        case ProgNodeValueType.BOOLEAN:
                            break;
                    }
                    break;
                case ProgNodeValueType.BOOLEAN:
                    switch (right.Type)
                    {
                        case ProgNodeValueType.FLOAT:
                            break;
                        case ProgNodeValueType.INTEGER:
                            break;
                        case ProgNodeValueType.STRING:
                            break;
                        case ProgNodeValueType.BOOLEAN:
                            break;
                    }
                    break;
            }

            return (result);
        }
    }
}
