using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;

namespace LeoLib.scipt.execute
{
    class ProgNodePower : ProgNodeBinaryOper
    {
        private const int TYPE_INTEGER = 1;
        private const int TYPE_FLOAT = 2;

        public ProgNodePower(ProgNode leftExp, ProgNode rightExp)
            : base(leftExp, rightExp)
        {
            
        }

        public override ProgNodeValue ExecBoxing(ProgNodeValue left, ProgNodeValue right, int type)
        {
            ProgNodeValue result = null;

            switch (type)
            {
                case TYPE_FLOAT:
                    float fvalue = (float)(Math.Pow(left.GetFloat(), right.GetFloat()));
                    result = new ProgNodeValue(fvalue);
                    break;
            }

            return (result);
        }

        public override void InitBoxing()
        {
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.INTEGER, TYPE_FLOAT);

            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.FLOAT, TYPE_FLOAT);
            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.INTEGER, TYPE_FLOAT);
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.FLOAT, TYPE_FLOAT);
        }
    }
}
