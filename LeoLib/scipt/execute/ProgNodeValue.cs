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
    }
}