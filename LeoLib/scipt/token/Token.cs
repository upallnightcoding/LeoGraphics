using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public class Token
    {
        private TokenType type = TokenType.UNKNOWN;

        private int ivalue = 0;
        private float fvalue = 0.0f;
        private string svalue = "";
        private char cvalue = ' ';
        private bool bvalue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Token(char simpleToken)
        {
            this.type = TokenType.SIMPLE_TOKEN;

            this.cvalue = simpleToken;
        }

        public Token(string svalue, TokenType type)
        {
            this.type = type;

            this.svalue = svalue;
        }

        public Token(Number whole)
        {
            this.type = TokenType.INTEGER;

            this.ivalue = whole.getAsWholeNumber();
        }

        public Token(Number whole, Number fraction)
        {
            this.type = TokenType.FLOAT;

            this.fvalue = whole.getAsWholeNumber() + fraction.getAsFractional();
        }

        public Token(bool bvalue)
        {
            this.type = TokenType.BOOLEAN;

            this.bvalue = bvalue;
        }

        /***************************/
        /*** Predicate Functoins ***/
        /***************************/

        public bool IsEos()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (cvalue == Constant.EOS));
        }

        public bool IsSeparator()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (cvalue == Constant.EXP_SEPARATOR));
        }

        /*********************/
        /*** Get Functions ***/
        /*********************/

        public TokenType GetTokenType()
        {
            return (type);
        }

        public float GetFloat()
        {
            return (fvalue);
        }

        public int GetInteger()
        {
            return (ivalue);
        }

        public string GetString()
        {
            return (svalue);
        }

        public bool GetBoolean()
        {
            return (bvalue);
        }

        public void Print()
        {
            switch (type) {
                case TokenType.INTEGER:
                    Console.WriteLine("Value (INTEGER): " + ivalue);
                    break;
                case TokenType.FLOAT:
                    Console.WriteLine("Value (FLOAT): " + fvalue);
                    break;
                case TokenType.KEYWORD:
                case TokenType.STRING:
                    Console.WriteLine("Value (" + type.ToString() + "): " + svalue);
                    break;
                case TokenType.SIMPLE_TOKEN:
                    Console.WriteLine("Value (SIMPLE): " + cvalue);
                    break;
                case TokenType.BOOLEAN:
                    Console.WriteLine("Value (BOOLEAN): " + bvalue);
                    break;
            }
        }
    }
}
