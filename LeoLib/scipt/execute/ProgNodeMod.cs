using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;

namespace LeoLib.scipt.execute
{
    class ProgNodeMod : ProgNodeBinaryOper
    {
        private const int TYPE_INTEGER = 1;

        public ProgNodeMod(ProgNode leftExp, ProgNode rightExp)
            : base(leftExp, rightExp)
        {

        }

        public override ProgNodeValue ExecBoxing(ProgNodeValue left, ProgNodeValue right, int type)
        {
            ProgNodeValue result = null;

            switch (type)
            {
                case TYPE_INTEGER:
                    int ivalue = left.GetInteger() % right.GetInteger();
                    result = new ProgNodeValue(ivalue);
                    break;
            }

            return (result);
        }

        public override void InitBoxing()
        {
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.INTEGER, TYPE_INTEGER);
        }
    }
}
