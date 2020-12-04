using LeoLib.script;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib
{
    public class Script
    {
        // Source code string
        private string source = "   print 1, 2, 3, \" Test Text \", 123.345, 0.098;";
        //private string source = "   print 1, 2, 3, 123.345, 0.098;";

        // Active source code character pointer
        private int sourcePtr = 0;

        // Size of source code (characters)
        private int sourceSize = 0;

        // End of file flag
        private bool eof = false;

        public Script()
        {
            sourceSize = source.Length;

            SkipBlanks();

            GetToken();
            ProgCmdPrint cmdPrint = new ProgCmdPrint();
            ProgNode progNode = cmdPrint.Parse(this);
            progNode.Evaluate();

            while (IsNotEof())
            {
                Token token = GetToken();

                token.Print();
            }
        }

        public Token GetToken()
        {
            Token token = null;
            char sourceChar = GetChar();

            if(Char.IsDigit(sourceChar))
            {
                token = GetNumber();
            } else if(Char.IsLetter(sourceChar))
            {
                token = GetKeyWord();
            } else if(sourceChar == Constant.STRING_CHARACTER)
            {
                token = GetString();
            } else if (Constant.SIMPLE_TOKENS.Contains(sourceChar))
            {
                token = GetSimpleToken();
            }

            SkipBlanks();

            return (token);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private Token GetSimpleToken()
        {
            char simpleToken = GetChar();

            MoveNextChar();

            return (new Token(simpleToken));
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

            if (++sourcePtr < sourceSize)
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
            if (!(++sourcePtr < sourceSize))
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

        private bool IsNotEof()
        {
            return (!eof);
        }
    }
}
