using LeoLib.game;
using LeoLib.scipt.command;
using LeoLib.scipt.execute;
using LeoLib.scipt.token;
using LeoLib.script;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;

namespace LeoLib.scipt
{
    public class Script
    {
        private Parser parser = null;

        private bool errorSwitch = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Script(Parser parser)
        {
            this.parser = parser;

            while(parser.IsNotEof())
            {
                ProgNode node = GetCommand();

                if (!errorSwitch) 
                { 
                    node.Evaluate();
                }
            }
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void SyntaxError(ErrorCode code)
        {
            parser.DisplayCodeLocation();
            Console.WriteLine(ErrorMsg.GetInstance().GetMsg(code));
            errorSwitch = true;
        }

        public ProgNode ReadCodeBlock()
        {
            ProgNodeExec codeBlock = new ProgNodeExec();
            
            ProgNode command = GetCommand();

            while ((command != null) && (!command.IsEndOfCodeBlock)) 
            {
                codeBlock.Add(command);

                command = GetCommand();
            }

            return (codeBlock);
        }

        public ProgNode GetCommand()
        {
            string keyword = parser.GetToken().GetString().ToUpper();

            ProgCmd command = parser.GetProgCmd(keyword);

            ProgNode node = null;

            if (command != null)
            {
                node = command.Interpret(this);
            } else
            {
                SyntaxError(ErrorCode.ERROR_UNKNOWN_COMMAND);
            }

            return (node);
        }

        public Token GetToken()
        {
            return (parser.GetToken());
        }

        public ProgNode Expression()
        {
            Stack<Token> operStack = new Stack<Token>();
            Stack<ProgNode> varStack = new Stack<ProgNode>();

            operStack.Push(new Token(TokenSimpleType.BOTTOM_EXP_STACK));

            Token token = parser.GetToken();

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

                token = parser.GetToken();
            }

            while (!operStack.Peek().IsBottomOfOperStack())
            {
                PopOperStack(operStack, varStack);
            }

            ProgNode value = varStack.Peek();
            value.EndingToken = token;

            return (value);
        }

        /************************************/
        /*** Private Expression Functions ***/
        /************************************/

        private void PushLeftParen(Token token, Stack<Token> operStack)
        {
            operStack.Push(token);
        }

        private void PushOperOnStack(Token token, Stack<Token> operStack, Stack<ProgNode> varStack)
        {
            while (token.Rank() <= operStack.Peek().Rank())
            {
                PopOperStack(operStack, varStack);
            }

            operStack.Push(token);
        }

        private void PopLeftParen(Stack<Token> operStack, Stack<ProgNode> varStack)
        {
            while (!operStack.Peek().IsLeftParen())
            {
                PopOperStack(operStack, varStack);
            }

            operStack.Pop();
        }

        private void PopOperStack(Stack<Token> operStack, Stack<ProgNode> varStack)
        {
            ProgNode node = null;

            ProgNode right = varStack.Pop();
            ProgNode left = varStack.Pop();

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

        private void PushVarStack(Token token, Stack<ProgNode> varStack)
        {
            varStack.Push(new ProgNodeValue(token));
        }
    }
}
