using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script.execute
{
    class ProgNodeValue : ProgNode
    {
        private ProgExecValueType type = ProgExecValueType.UNKNOWN;

        private int ivalue = 0;
        private float fvalue = 0.0f;
        private string svalue = "";
        private bool bvalue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeValue(Token token)
        { 
            switch(token.GetTokenType())
            {
                case TokenType.INTEGER:
                    type = ProgExecValueType.INTEGER;
                    ivalue = token.GetInteger();
                    break;
                case TokenType.FLOAT:
                    type = ProgExecValueType.FLOAT;
                    fvalue = token.GetFloat();
                    break;
                case TokenType.KEYWORD:
                    type = ProgExecValueType.KEYWORD;
                    svalue = token.GetString();
                    break;
                case TokenType.STRING:
                    type = ProgExecValueType.STRING;
                    svalue = token.GetString();
                    break;
            }
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate()
        {
            return (this);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public float GetFloat()
        {
            float value = 0.0f;

            switch(type)
            {
                case ProgExecValueType.FLOAT:
                    value = fvalue;
                    break;
                case ProgExecValueType.INTEGER:
                    value = ivalue;
                    break;
                case ProgExecValueType.STRING:
                    value = float.Parse(svalue);
                    break;
            }

            return (value);
        }

        public float GetInteger()
        {
            int value = 0;

            switch (type)
            {
                case ProgExecValueType.FLOAT:
                    value = (int)fvalue;
                    break;
                case ProgExecValueType.INTEGER:
                    value = ivalue;
                    break;
                case ProgExecValueType.STRING:
                    value = int.Parse(svalue);
                    break;
            }

            return (value);
        }

        public string GetString()
        {
            string value = "";

            switch (type)
            {
                case ProgExecValueType.FLOAT:
                    value = fvalue.ToString();
                    break;
                case ProgExecValueType.INTEGER:
                    value = ivalue.ToString();
                    break;
                case ProgExecValueType.STRING:
                    value = svalue;
                    break;
            }

            return (value);
        }
    }
}