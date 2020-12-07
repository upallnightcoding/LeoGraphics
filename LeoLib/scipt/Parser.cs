using LeoLib.scipt.execute;
using LeoLib.scipt.token;
using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Parser
    {
        private string source = null;

        // Active source code character pointer
        private int sourcePtr = 0;

        // Size of source code (characters)
        private int size = 0;

        // End of file flag
        private bool eof = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Parser(string code)
        {
            source = code;
            size = code.Length;

            SkipBlanks();
        }

        public Parser(string[] code)
        {
            source = "";

            foreach (string line in code) 
            {
                source += line;
            }

            size = source.Length;

            SkipBlanks();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public Token GetToken()
        {
            Token token = null;

            if (IsNotEof())
            {
                char sourceChar = GetChar();

                if (Char.IsDigit(sourceChar))
                {
                    token = GetNumber();
                }
                else if (Char.IsLetter(sourceChar))
                {
                    token = GetKeyWord();
                }
                else if (sourceChar == Constant.STRING_CHARACTER)
                {
                    token = GetString();
                }
                else if (Constant.SIMPLE_TOKENS.Contains(sourceChar))
                {
                    token = GetSimpleToken();
                }

                SkipBlanks();
            } else
            {
                token = new Token(TokenType.EOF);
            }

            return (token);
        }

        public script.ProgNode Expression()
        {
            Stack<Token> operStack = new Stack<Token>();
            Stack<script.ProgNode> varStack = new Stack<script.ProgNode>();

            operStack.Push(new Token(TokenSimpleType.BOTTOM_EXP_STACK));

            Token token = GetToken();

            while (!token.IsEoe())
            {
                if (token.IsOperator())
                {
                    PushOperOnStack(token, operStack, varStack);
                }
                else if (token.IsLeftParen())
                {
                    PushLeftParen(token, operStack);
                }
                else if (token.IsRightParen())
                {
                    PopLeftParen(operStack, varStack);
                }
                else
                {
                    PushVarStack(token, varStack);
                }

                token = GetToken();
            }

            while (!operStack.Peek().IsBottomOfOperStack())
            {
                PopOperStack(operStack, varStack);
            }

            script.ProgNode value = varStack.Peek();
            value.EndingToken = token;

            return (value);
        }

        public bool IsNotEof()
        {
            return (!eof);
        }

        /************************************/
        /*** Private Expression Functions ***/
        /************************************/

        private void PushLeftParen(Token token, Stack<Token> operStack)
        {
            operStack.Push(token);
        }

        private void PushOperOnStack(Token token, Stack<Token> operStack, Stack<script.ProgNode> varStack)
        {
            while (token.Rank() <= operStack.Peek().Rank())
            {
                PopOperStack(operStack, varStack);
            }

            operStack.Push(token);
        }

        private void PopLeftParen(Stack<Token> operStack, Stack<script.ProgNode> varStack)
        {
            while (!operStack.Peek().IsLeftParen())
            {
                PopOperStack(operStack, varStack);
            }

            operStack.Pop();
        }

        private void PopOperStack(Stack<Token> operStack, Stack<script.ProgNode> varStack)
        {
            script.ProgNode node = null;

            script.ProgNode right = varStack.Pop();
            script.ProgNode left = varStack.Pop();

            Token oper = operStack.Pop();

            switch (oper.GetSimpleType())
            {
                case TokenSimpleType.PLUS:
                    node = new ProgNodePlus(left, right);
                    break;
                case TokenSimpleType.MULTIPLY:
                    node = new ProgNodeMultiply(left, right);
                    break;
                case TokenSimpleType.MINUS:
                    node = new ProgNodeMinus(left, right);
                    break;
                case TokenSimpleType.DIVIDE:
                    node = new ProgNodeDivide(left, right);
                    break;
            }

            varStack.Push(node);
        }

        private void PushVarStack(Token token, Stack<script.ProgNode> varStack)
        {
            varStack.Push(new script.execute.ProgNodeValue(token));
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private Token GetSimpleToken()
        {
            TokenSimpleType simpleType = TokenSimpleType.UNKNOWN;
            char simpleToken = GetChar();

            switch(simpleToken)
            {
                case '+':
                    simpleType = TokenSimpleType.PLUS;
                    break;
                case '-':
                    simpleType = TokenSimpleType.MINUS;
                    break;
                case '*':
                    simpleType = TokenSimpleType.MULTIPLY;
                    break;
                case '/':
                    simpleType = TokenSimpleType.DIVIDE;
                    break;
                case ',':
                    simpleType = TokenSimpleType.EXP_SEPARATOR;
                    break;
                case ';':
                    simpleType = TokenSimpleType.EOS;
                    break;
                case '(':
                    simpleType = TokenSimpleType.LEFT_PAREN;
                    break;
                case ')':
                    simpleType = TokenSimpleType.RIGHT_PAREN;
                    break;
            }

            MoveNextChar();

            return (new Token(simpleType));
        }

        private Token GetString()
        {
            string strg = "";

            MoveNextChar();

            char sourceChar = GetChar();

            while (IsNotEof() && !IsChar(Constant.STRING_CHARACTER))
            {
                strg += sourceChar;

                sourceChar = GetNextChar();
            }

            MoveNextChar();

            return (new Token(strg, TokenType.STRING));
        }

        private Token GetKeyWord()
        {
            string keyword = "";

            char sourceChar = GetChar();

            while (IsNotEof() && Char.IsLetterOrDigit(sourceChar))
            {
                keyword += sourceChar;

                sourceChar = GetNextChar();
            }

            return (new Token(keyword, TokenType.KEYWORD));
        }

        private Token GetNumber()
        {
            Token token = null;

            if (IsNotEof())
            {
                Number whole = GetInteger();

                if (IsNotEof() && IsChar(Constant.FRACTIONAL_DOT))
                {
                    MoveNextChar();

                    Number fraction = GetInteger();

                    token = new Token(whole, fraction);
                }
                else
                {
                    token = new Token(whole);
                }
            }

            return (token);
        }

        private Number GetInteger()
        {
            char sourceChar = GetChar();
            int value = 0;
            int n = 0;

            while(IsNotEof() && Char.IsDigit(sourceChar))
            {
                value = 10 * value + (sourceChar - '0');

                n++;

                sourceChar = GetNextChar();
            }

            return (new Number(value, n));
        }

        private bool IsChar(char target)
        {
            return (target == GetChar());
        }

        /**
         * GetChar() - Returns the current active programming line character.  
         * The "source" string contains the source code and the "sourcePtr" 
         * refers to the active character in the array.
         **/

        private char GetChar()
        {
            return (source[sourcePtr]);
        }

        /// <summary>
        /// GetNextChar() - Moves to the next active source code character and <br/>
        /// returns its value.  If the next character does not exist and the <br/>
        /// program reaches the end of the source code string, the "eof" flag <br/>
        /// is set.
        /// </summary>
        /// <returns>The next active source code character</returns>
        private char GetNextChar()
        {
            char sourceChar = ' ';

            if (++sourcePtr < size)
            {
                sourceChar = GetChar();
            } else
            {
                eof = true;
            }

            return (sourceChar);
        }

        private void MoveNextChar()
        {
            if (!(++sourcePtr < size))
            {
                eof = true;
            }
        }

        private void SkipBlanks()
        {
            if (IsNotEof())
            {
                char sourceChar = GetChar();

                while (Char.IsWhiteSpace(sourceChar) && IsNotEof())
                {
                    sourceChar = GetNextChar();
                }
            }
        }

       
    }
}
