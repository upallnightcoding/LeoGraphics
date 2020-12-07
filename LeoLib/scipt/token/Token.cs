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

        public Token()
        {

        }

        public Token(TokenType type)
        {
            this.type = type;
        }

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

        /************************/
        /*** Public Functions ***/
        /************************/

        public int Rank()
        {
            int value = -1;

            if (IsSimpleToken())
            {
                switch(simpleType)
                {
                    case TokenSimpleType.DIVIDE:
                    case TokenSimpleType.MULTIPLY:
                        value = 20;
                        break;
                    case TokenSimpleType.MINUS:
                    case TokenSimpleType.PLUS:
                        value = 10;
                        break;
                    case TokenSimpleType.LEFT_PAREN:
                        value = 1;
                        break;
                    case TokenSimpleType.BOTTOM_EXP_STACK:
                        value = 0;
                        break;
                }
            }

            return (value);
        }

        /***************************/
        /*** Predicate Functoins ***/
        /***************************/

        public bool IsOperator()
        {
            bool oper = false;

            if (IsSimpleToken())
            {
                switch (simpleType)
                {
                    case TokenSimpleType.DIVIDE:
                    case TokenSimpleType.MULTIPLY:
                    case TokenSimpleType.MINUS:
                    case TokenSimpleType.PLUS:
                        oper = true;
                        break;
                }
            }

            return (oper);
        }

        public bool IsEof()
        {
            return (type == TokenType.EOF);
        }

        public bool  IsEoe()
        {
            return (IsSeparator() || IsEos() || IsEof());
        }

        /// <summary>
        /// IsEos() - Returns true, if the current token is an end of <br/>
        /// statement token.  This token marks the end of a command that <br/>
        /// is marked by a semi-colon.  All commands should end in a <br/>
        /// semi-colon else a syntax error should be thrown. <br/>
        /// </summary>
        /// 
        /// <returns>true/false</returns>
        public bool IsEos()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.EOS));
        }

        public bool IsSeparator()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.EXP_SEPARATOR));
        }

        public bool IsSimpleToken()
        {
            return (type == TokenType.SIMPLE_TOKEN);
        }

        public bool IsLeftParen()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.LEFT_PAREN));
        }

        public bool IsRightParen()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.RIGHT_PAREN));
        }

        public bool IsBottomOfOperStack()
        {
            return ((type == TokenType.SIMPLE_TOKEN) && (simpleType == TokenSimpleType.BOTTOM_EXP_STACK));
        }

        /*********************/
        /*** Get Functions ***/
        /*********************/

        public TokenType GetTokenType()
        {
            return (type);
        }

        public TokenSimpleType GetSimpleType()
        {
            return (simpleType);
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
