using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;

namespace LeoLib.scipt.execute
{
    public class ProgNodeDivide : ProgNodeBinaryOper
    {
        private const int TYPE_INTEGER = 1;
        private const int TYPE_FLOAT = 2;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeDivide(ProgNode leftExp, ProgNode rightExp)
            : base(leftExp, rightExp)
        {

        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue ExecBoxing(ProgNodeValue left, ProgNodeValue right, int type)
        {
            ProgNodeValue result = null;

            switch (type)
            {
                case TYPE_FLOAT:
                    float fvalue = left.GetFloat() / right.GetFloat();
                    result = new ProgNodeValue(fvalue);
                    break;
                case TYPE_INTEGER:
                    int ivalue = left.GetInteger() / right.GetInteger();
                    result = new ProgNodeValue(ivalue);
                    break;
            }

            return (result);
        }

        public override void InitBoxing()
        {
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.INTEGER, TYPE_INTEGER);

            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.FLOAT, TYPE_FLOAT);
            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.INTEGER, TYPE_FLOAT);
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.FLOAT, TYPE_FLOAT);

            //SetBoxType(ProgNodeValueType.STRING, ProgNodeValueType.STRING, TYPE_STRING);
        }
    }
}
