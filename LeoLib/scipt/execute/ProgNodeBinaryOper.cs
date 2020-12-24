using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.execute
{
    public abstract class ProgNodeBinaryOper : ProgNode
    {
        private const int NUMBER_OF_SCRIPT_TYPES = Constant.NUMBER_OF_SCRIPT_TYPES;

        private readonly int[,] boxing = null;

        private readonly ProgNode leftExp = null;
        private readonly ProgNode rightExp = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeBinaryOper(ProgNode leftExp, ProgNode rightExp)
        {
            this.leftExp = leftExp;
            this.rightExp = rightExp;
            this.boxing = new int[NUMBER_OF_SCRIPT_TYPES, NUMBER_OF_SCRIPT_TYPES];

            InitBoxing();
        }

        /*****************************/
        /*** Abstraction Functions ***/
        /*****************************/

        public abstract void InitBoxing();
        public abstract ProgNodeValue ExecBoxing(ProgNodeValue left, ProgNodeValue right, int type);

        /***************************/
        /*** Protected Functions ***/
        /***************************/

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            ProgNodeValue left = leftExp.Evaluate(context);
            ProgNodeValue right = rightExp.Evaluate(context);

            int type = GetBoxType(left, right);

            return (ExecBoxing(left, right, type));
        }

        protected void SetBoxType(ProgNodeValueType left, ProgNodeValueType right, int type)
        {
            boxing[(int)left, (int)right] = type;
        }

        protected int GetBoxType(ProgNodeValue left, ProgNodeValue right)
        {
            return (boxing[(int)left.Type, (int)right.Type]);
        }
    }
}
