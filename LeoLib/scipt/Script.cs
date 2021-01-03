using LeoLib.game;
using LeoLib.scipt.execute;
using LeoLib.script;
using LeoLib.script.execute;
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

            while(!parser.IsEof())  
            {
                ProgNode node = GetCommand();

                if (!errorSwitch) 
                {
                    ProgNodeContext context = new ProgNodeContext();

                    node.Evaluate(context);
                }
            }
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void SyntaxError(ErrorCode code)
        {
            parser.DisplayErrorAndRecover(code);

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
            ProgNode node = null;

            string variable = parser.GetToken().GetString();
            string keyword = variable.ToUpper();

            ProgCmd command = parser.GetProgCmd(keyword);

            if (command != null)
            {
                node = command.Interpret(this);
            } else
            {
                Token assignToken = parser.GetToken();

                ProgNode expression = Expression();

                node = new ProgNodeAssign(variable, expression);
            }

            return (node);
        }

        /// <summary>
        /// GetToken() - Returns the next token read by the parser.  If the parser <br/>
        /// is at the end-of-file, the end-of-file token is returned.  This function <br/>
        /// should always return an object.  Returning a null is an application error.<br/>
        /// </summary>
        /// 
        /// <returns>Next source code token</returns>
        public Token GetToken()
        {
            return (parser.GetToken());
        }

        public ProgNode Expression()
        {
            Stack<Token> operStack = new Stack<Token>();
            Stack<ProgNode> varStack = new Stack<ProgNode>();

            operStack.Push(new Token(TokenType.BOTTOM_EXP_STACK));

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

        /// <summary>
        /// Pushes a left parenthesis on the operator stack.  The left <br/>
        /// parenthesis must be balanced by a right parenthesis to <br/>
        /// complete the expression evaluation.  Failure to balance <br/>
        /// the parenthesis will result in a runtime error.<br/>
        /// </summary>
        /// 
        /// <param name="token"></param>
        /// <param name="operStack"></param>
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

            TokenType type = operStack.Pop().GetDataType();

            switch (type)
            {
                case TokenType.PLUS:
                    node = new ProgNodePlus(left, right);
                    break;
                case TokenType.MULTIPLY:
                    node = new ProgNodeMultiply(left, right);
                    break;
                case TokenType.MINUS:
                    node = new ProgNodeMinus(left, right);
                    break;
                case TokenType.DIVIDE:
                    node = new ProgNodeDivide(left, right);
                    break;
                case TokenType.POWER:
                    node = new ProgNodePower(left, right);
                    break;
                case TokenType.MODULUS:
                    node = new ProgNodeMod(left, right);
                    break;
                case TokenType.LT:
                case TokenType.LE:
                case TokenType.GT:
                case TokenType.GE:
                case TokenType.NE:
                    node = new ProgNodeLogicalOper(type, left, right);
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
