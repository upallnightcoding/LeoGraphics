using LeoLib.script;
using LeoLib.script.execute;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.boxing
{

    class BoxingMultiply
    {
        enum BoxType
        {
            UNKNOWN,
            FLOAT,
            INTEGER,
            STRING
        }

        private const int NUMBER_OF_SCRIPT_TYPES = Constant.NUMBER_OF_SCRIPT_TYPES;

        private BoxType[,] boxing = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public BoxingMultiply()
        {
            boxing = new BoxType[NUMBER_OF_SCRIPT_TYPES, NUMBER_OF_SCRIPT_TYPES];

            Initialize();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public ProgNodeValue Evaluate(ProgNodeValue left, ProgNodeValue right)
        {
            ProgNodeValue result = null;

            BoxType type = boxing[(int)left.Type, (int)right.Type];

            switch(type)
            {
                case BoxType.UNKNOWN:
                    break;
                case BoxType.FLOAT:
                    float fvalue = left.GetFloat() * right.GetFloat();
                    result = new ProgNodeValue(fvalue);
                    break;
                case BoxType.INTEGER:
                    int ivalue = left.GetInteger() * right.GetInteger();
                    result = new ProgNodeValue(ivalue);
                    break;
                case BoxType.STRING:
                    //string svalue = left.GetString() + right.GetString();
                    //result = new ProgNodeValue(svalue);
                    break;
            }

            return (result);
        }

        private void Initialize()
        {
            Box(ProgNodeValueType.INTEGER, ProgNodeValueType.INTEGER, BoxType.INTEGER);

            Box(ProgNodeValueType.FLOAT, ProgNodeValueType.FLOAT, BoxType.FLOAT);
            Box(ProgNodeValueType.FLOAT, ProgNodeValueType.INTEGER, BoxType.FLOAT);
            Box(ProgNodeValueType.INTEGER, ProgNodeValueType.FLOAT, BoxType.FLOAT);

            //Box(ProgNodeValueType.STRING, ProgNodeValueType.STRING, BoxType.STRING);
        }

        private void Box(ProgNodeValueType left, ProgNodeValueType right, BoxType type)
        {
            boxing[(int)left, (int)right] = type;
        }
    }
}
