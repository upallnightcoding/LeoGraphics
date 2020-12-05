using LeoLib.scipt.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public class Token
    {
        private TokenType type = TokenType.UNKNOWN;
        private TokenSimpleType simpleType = TokenSimpleType.UNKNOWN;

        private int ivalue = 0;
        private float fvalue = 0.0f;
        private string svalue = "";
        private char cvalue = ' ';
        private bool bvalue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Token(TokenSimpleType simpleType)
        {
            this.type = TokenType.SIMPLE_TOKEN;

            this.simpleType = simpleType;
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

        public bool IsEoe()
        {
            return (IsSeparator() || IsEos());
        }

        public bool IsEos()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.EOS));
        }

        public bool IsSeparator()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.EXP_SEPARATOR));
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
                    Console.WriteLine("Value (SIMPLE): " + simpleType);
                    break;
                case TokenType.BOOLEAN:
                    Console.WriteLine("Value (BOOLEAN): " + bvalue);
                    break;
            }
        }
    }
}
