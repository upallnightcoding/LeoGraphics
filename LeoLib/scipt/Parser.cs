using LeoLib.game;
using LeoLib.scipt.command;
using LeoLib.scipt.symtable;
using LeoLib.script;
using System;
using System.Collections.Generic;

namespace LeoLib
{
    public class Parser
    {
        private string[] source = null;

        // Active source code character pointer
        private int sourceChar = 0;
        private int sourceLine = 0;

        // End of file flag
        private bool eof = false;

        private int sourceLength = 0;

        private Dictionary<string, ProgCmd> cmdDict = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Parser(string[] code)
        {
            cmdDict = new Dictionary<string, ProgCmd>();

            Add(new ProgCmdEnd());
            Add(new ProgCmdPrint());
            Add(new ProgCmdProgram());
            Add(new ProgCmdDeclare("INTEGER", SymbolTableRecType.INTEGER));
            Add(new ProgCmdDeclare("STRING", SymbolTableRecType.STRING));
            Add(new ProgCmdDeclare("BOOLEAN", SymbolTableRecType.BOOLEAN));
            Add(new ProgCmdDeclare("FLOAT", SymbolTableRecType.FLOAT));
            
            source = code;
            sourceLength = code.Length;

            SkipBlanks();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public Token GetToken()
        {
            Token token = null;

            if (!IsEof())
            {
                char sourceChar = GetChar();

                if (Char.IsDigit(sourceChar) || (sourceChar == '.'))
                {
                    token = GetNumber();
                }
                else if (Char.IsLetter(sourceChar) || (sourceChar == '_'))
                {
                    token = GetKeyWord();
                }
                else if ((sourceChar == Constant.STRING_SINGLE_QUOTE) 
                    || (sourceChar == Constant.STRING_DOUBLE_QUOTE))
                {
                    token = GetString(sourceChar);
                }
                else if (Constant.SIMPLE_TOKENS.Contains(sourceChar))
                {
                    token = GetSimpleToken();
                }
                else if (Constant.LOGICAL_OPER.Contains(sourceChar))
                {
                    token = GetLogicalOper();
                }

                SkipBlanks();
            } else
            {
                token = new Token(TokenType.EOF);
            }

            return (token);
        }

        public ProgCmd GetProgCmd(string keyword)
        {
            ProgCmd command = null;

            if (!cmdDict.TryGetValue(keyword, out command))
            {
                command = null;
            } 

            return (command);
        }

        /// <summary>
        /// IsEof() - Returns the current end-of-file state of the parser.  <br/>
        /// If the parser has reached the end-of-file, this function <br/>
        /// returns a true.  A false is returned if the parser has NOT <br/>
        /// reached the end-of-file state.
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEof()
        {
            return (eof);
        }

        public void DisplayErrorAndRecover(ErrorCode code)
        {
            string errMsg = ErrorMsg.GetInstance().GetMsg(code);

            Console.WriteLine(String.Format("Line({0, 4}): {1}", sourceChar, source[sourceLine]));
            Console.WriteLine(new string(' ', sourceChar + 12) + '^');
            Console.WriteLine(errMsg);

            Token token = GetToken();

            while (!IsEof() && !token.IsEos())
            {
                token = GetToken();
            }
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// Add() - Adds a command to the command dictionary.  The command is <br/>
        /// added to the dictionary with its name as the key.  The command is <br/>
        /// retrieved from the dictionary each time it is needed for parsing.  
        /// </summary>
        /// <param name="command">New command to populate the dictionary</param>
        private void Add(ProgCmd command)
        {
            if (command != null)
            {
                cmdDict.Add(command.CommandName, command);
            }
        }

        private Token GetLogicalOper()
        {
            TokenType type = TokenType.UNKNOWN;

            char firstChar = GetChar();
            char secondChar = GetNextChar();

            switch (firstChar)
            {
                case '<':
                    type = TokenType.LT;
                    break;
                case '>':
                    type = TokenType.GT;
                    break;
                case '!':
                    type = TokenType.NOT;
                    break;
            }

            if (secondChar == '=')
            {
                switch(type)
                {
                    case TokenType.LT:
                        type = TokenType.LE;
                        break;
                    case TokenType.GT:
                        type = TokenType.GE;
                        break;
                    case TokenType.NOT:
                        type = TokenType.NE;
                        break;
                }

                MoveNextChar();
            }


            return (new Token(type));
        }

        private Token GetSimpleToken()
        {
            TokenType type = TokenType.UNKNOWN;
            char simpleToken = GetChar();

            switch(simpleToken)
            {
                case '^':
                    type = TokenType.POWER;
                    break;
                case '%':
                    type = TokenType.MODULUS;
                    break;
                case '+':
                    type = TokenType.PLUS;
                    break;
                case '-':
                    type = TokenType.MINUS;
                    break;
                case '*':
                    type = TokenType.MULTIPLY;
                    break;
                case '/':
                    type = TokenType.DIVIDE;
                    break;
                case ',':
                    type = TokenType.EXP_SEPARATOR;
                    break;
                case ';':
                    type = TokenType.EOS;
                    break;
                case '(':
                    type = TokenType.LEFT_PAREN;
                    break;
                case ')':
                    type = TokenType.RIGHT_PAREN;
                    break;
                case '=':
                    type = TokenType.ASSIGN;
                    break;
            }

            MoveNextChar();

            return (new Token(type));
        }

        private Token GetString(char stringStart)
        {
            string strg = "";

            MoveNextChar();

            char sourceChar = GetChar();

            while (!IsEof() && !IsChar(stringStart))
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

            while (!IsEof() && ((Char.IsLetterOrDigit(sourceChar)) || (sourceChar == '_')))
            {
                keyword += sourceChar;

                sourceChar = GetNextChar();
            }

            return (new Token(keyword, TokenType.KEYWORD));
        }

        private Token GetNumber()
        {
            Token token = null;

            if (!IsEof())
            {
                Number whole = GetInteger();

                if (!IsEof() && IsChar(Constant.FRACTIONAL_DOT))
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

        /// <summary>
        /// GetInteger() - Returns an integer constant as a Number object.  <br/>
        /// This function reads the integer value one character at a time.  <br/>
        /// It continues reading until it reaches the end-of-file or the <br/>
        /// first non-digit.
        /// </summary>
        /// 
        /// <returns>Number Object</returns>
        private Number GetInteger()
        {
            char sourceChar = GetChar();
            int value = 0;
            int n = 0;

            while(!IsEof() && Char.IsDigit(sourceChar))
            {
                value = 10 * value + (sourceChar - '0');

                n++;

                sourceChar = GetNextChar();
            }

            return (new Number(value, n));
        }

        /// <summary>
        /// IsChar() - Returns true if the current active source code <br/>
        /// character is equal to the target character.  If it is not, <br/>
        /// a false is returned.
        /// </summary>
        /// <param name="target">Source character to test against</param>
        /// <returns>true/false</returns>
        private bool IsChar(char target)
        {
            return (target == GetChar());
        }

        /// <summary>
        /// GetChar() - Returns the current active programing line character.  <br/>
        /// The source code pointer, refers to the active character in the <br/>
        /// source code string.  This function does not check for end-of-file, <br/>
        /// this should be done by the invoking function.
        /// </summary>
        /// 
        /// <returns>Source Code Character</returns>
        private char GetChar()
        {
            return (source[sourceLine][sourceChar]);
        }

        /// <summary>
        /// GetNextChar() - Moves to the next active source code character and <br/>
        /// returns its value.  If the next character does not exist and the <br/>
        /// program reaches the end of the source code string, the "eof" flag <br/>
        /// is set.
        /// </summary>
        /// 
        /// <returns>The next active source code character</returns>
        private char GetNextChar()
        {
            char sourceChar = ' ';

            MoveNextChar();

            if (!eof)
            {
                sourceChar = GetChar();
            }

            return (sourceChar);
        }

        /// <summary>
        /// MoveNextChar() - Moves the source code pointer to the very next <br/>
        /// source code character.  If the source code pointer reaches beyond <br/>
        /// the size of the source code, the end-of-file flag is set to true.
        /// </summary>
        private void MoveNextChar()
        {
            if (!(++sourceChar < source[sourceLine].Length))
            {
                if (!(++sourceLine < source.Length))
                {
                    eof = true;
                } else
                {
                    sourceChar = 0;
                }
            }
        }

        /// <summary>
        /// SkipBlanks() - Skips all of the white space that is between two <br/>
        /// tokens.  If the end-of-file flag has been set, then this function <br/>
        /// returns with no action taken.  If the end-of-file flag is set <br/>
        /// while skipping blanks, this function stops processing.
        /// </summary>
        private void SkipBlanks()
        {
            if (!IsEof())
            {
                char sourceChar = GetChar();

                while (Char.IsWhiteSpace(sourceChar) && !IsEof())
                {
                    sourceChar = GetNextChar();
                }
            }
        }

       
    }
}
