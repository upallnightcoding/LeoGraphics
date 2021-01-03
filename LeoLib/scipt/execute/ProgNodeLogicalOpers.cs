using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;

namespace LeoLib.scipt.execute
{
    public class ProgNodeLogicalOper : ProgNodeBinaryOper
    {
        private const int BOX_INTEGER = 1;
        private const int BOX_FLOAT = 2;

        private TokenType type = TokenType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeLogicalOper(TokenType type, ProgNode leftExp, ProgNode rightExp)
            : base(leftExp, rightExp)
        {
            this.type = type;
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue ExecBoxing(ProgNodeValue left, ProgNodeValue right, int action)
        {
            bool value = false;

            switch (action)
            {
                case BOX_INTEGER:
                    int iLeft = left.GetInteger();
                    int iRight = right.GetInteger();

                    switch(type)
                    {
                        case TokenType.LT:
                            value = iLeft < iRight;
                            break;
                        case TokenType.LE:
                            value = iLeft <= iRight;
                            break;
                        case TokenType.GT:
                            value = iLeft > iRight;
                            break;
                        case TokenType.GE:
                            value = iLeft >= iRight;
                            break;
                        case TokenType.NE:
                            value = iLeft != iRight;
                            break;
                    }

                    break;

                case BOX_FLOAT:
                    float fLeft = left.GetFloat();
                    float fRight = right.GetFloat();

                    switch (type)
                    {
                        case TokenType.LT:
                            value = fLeft < fRight;
                            break;
                        case TokenType.LE:
                            value = fLeft <= fRight;
                            break;
                        case TokenType.GT:
                            value = fLeft > fRight;
                            break;
                        case TokenType.GE:
                            value = fLeft >= fRight;
                            break;
                        case TokenType.NE:
                            value = fLeft != fRight;
                            break;
                    }

                    break;
            }

            return (new ProgNodeValue(value));
        }

        public override void InitBoxing()
        {
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.INTEGER, BOX_INTEGER);

            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.FLOAT, BOX_FLOAT);
            SetBoxType(ProgNodeValueType.FLOAT, ProgNodeValueType.INTEGER, BOX_FLOAT);
            SetBoxType(ProgNodeValueType.INTEGER, ProgNodeValueType.FLOAT, BOX_FLOAT);
        }
    }
}
