using System;

namespace LeoLib.script
{
    public class Token
    {
        private TokenType type = TokenType.UNKNOWN;

        private int ivalue = 0;
        private float fvalue = 0.0f;
        private string svalue = "";
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

        public Token(string svalue, TokenType type)
        {
            this.type = type;

            this.svalue = svalue;
        }

        public Token(Number whole)
        {
            this.type = TokenType.INTEGER;

            this.ivalue = whole.GetAsWholeNumber();
        }

        public Token(Number whole, Number fraction)
        {
            this.type = TokenType.FLOAT;

            this.fvalue = whole.GetAsWholeNumber() + fraction.GetAsFractional();
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

            switch(type)
            {
                case TokenType.POWER:
                case TokenType.MODULUS:
                    value = 30;
                    break;
                case TokenType.DIVIDE:
                case TokenType.MULTIPLY:
                    value = 20;
                    break;
                case TokenType.MINUS:
                case TokenType.PLUS:
                    value = 10;
                    break;
                case TokenType.LT:
                case TokenType.LE:
                case TokenType.GT:
                case TokenType.GE:
                case TokenType.NE:
                    value = 5;
                    break;
                case TokenType.LEFT_PAREN:
                    value = 1;
                    break;
                case TokenType.BOTTOM_EXP_STACK:
                    value = 0;
                    break;
            }

            return (value);
        }

        /***************************/
        /*** Predicate Functoins ***/
        /***************************/

        public bool IsOperator()
        {
            bool oper = false;

            switch (type)
            {
                // Logical Binary Operators
                //-------------------------
                case TokenType.LT:
                case TokenType.LE:
                case TokenType.GT:
                case TokenType.GE:
                case TokenType.NE:

                // Binary Operators
                //-----------------
                case TokenType.DIVIDE:
                case TokenType.MULTIPLY:
                case TokenType.MINUS:
                case TokenType.PLUS:
                case TokenType.POWER:
                case TokenType.MODULUS:
                    oper = true;
                    break;
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
            return (type == TokenType.EOS);
        }

        public bool IsAssign()
        {
            return (type == TokenType.ASSIGN);
        }

        public bool IsSeparator()
        {
            return (type == TokenType.EXP_SEPARATOR);
        }

        public bool IsLeftParen()
        {
            return (type == TokenType.LEFT_PAREN);
        }

        public bool IsRightParen()
        {
            return (type == TokenType.RIGHT_PAREN);
        }

        public bool IsBottomOfOperStack()
        {
            return (type == TokenType.BOTTOM_EXP_STACK);
        }

        /*********************/
        /*** Get Functions ***/
        /*********************/

        public TokenType GetDataType()
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
                case TokenType.BOOLEAN:
                    Console.WriteLine("Value (BOOLEAN): " + bvalue);
                    break;
            }
        }
    }
}
