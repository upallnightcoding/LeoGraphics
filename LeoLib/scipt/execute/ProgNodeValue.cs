using LeoLib.scipt;
using LeoLib.scipt.execute;
using LeoLib.scipt.symtable;
using LeoLib.script.token;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script.execute
{
    public class ProgNodeValue : ProgNode
    {
        public ProgNodeValueType Type { get; set; } = ProgNodeValueType.UNKNOWN;
        public ArgList Arguments { get; set; } = null;

        private int ivalue = 0;
        private float fvalue = 0.0f;
        private string svalue = "";
        private bool bvalue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNodeValue(Token token)
        { 
            switch(token.GetDataType())
            {
                case TokenType.INTEGER:
                    Type = ProgNodeValueType.INTEGER;
                    ivalue = token.GetInteger();
                    break;
                case TokenType.FLOAT:
                    Type = ProgNodeValueType.FLOAT;
                    fvalue = token.GetFloat();
                    break;
                case TokenType.KEYWORD:
                    Type = ProgNodeValueType.KEYWORD;
                    svalue = token.GetString();
                    break;
                case TokenType.STRING:
                    Type = ProgNodeValueType.STRING;
                    svalue = token.GetString();
                    break;
                case TokenType.BOOLEAN:
                    Type = ProgNodeValueType.BOOLEAN;
                    bvalue = token.GetBoolean();
                    break;
            }
        }

        public ProgNodeValue(float value)
        {
            Type = ProgNodeValueType.FLOAT;

            fvalue = value;
        }

        public ProgNodeValue(int value)
        {
            Type = ProgNodeValueType.INTEGER;

            ivalue = value;
        }

        public ProgNodeValue(string value)
        {
            Type = ProgNodeValueType.STRING;

            svalue = value;
        }

        public ProgNodeValue(bool value)
        {
            Type = ProgNodeValueType.BOOLEAN;

            bvalue = value;
        }

        /**************************/
        /*** Override Functions ***/
        /**************************/

        public override ProgNodeValue Evaluate(ProgNodeContext context)
        {
            ProgNodeValue value = null;

            if (Type == ProgNodeValueType.KEYWORD)
            {
                SymbolTableRec record = context.SymTable.GetSymbolTableRec(svalue);

                if (record != null)
                {
                    switch(record.Designation)
                    {
                        case SymbolTableRecDesig.SCALAR:
                            value = record.GetValue(0);
                            break;
                        case SymbolTableRecDesig.ARRAY:
                            break;
                        case SymbolTableRecDesig.FUNCTION:
                            value = record.Function.Evaluate(context, Arguments);
                            break;
                    }
                }
            } else
            {
                value = this;
            }

            return (value);
        }

        /****************************/
        /*** Public Get Functions ***/
        /****************************/

        public float GetFloat()
        {
            float value = 0.0f;

            switch(Type)
            {
                case ProgNodeValueType.FLOAT:
                    value = fvalue;
                    break;
                case ProgNodeValueType.INTEGER:
                    value = ivalue;
                    break;
                case ProgNodeValueType.STRING:
                    value = float.Parse(svalue);
                    break;
                case ProgNodeValueType.BOOLEAN:
                    value = (bvalue) ? 1.0f : 0.0f;
                    break;
            }

            return (value);
        }

        public int GetInteger()
        {
            int value = 0;

            switch (Type)
            {
                case ProgNodeValueType.FLOAT:
                    value = (int)fvalue;
                    break;
                case ProgNodeValueType.INTEGER:
                    value = ivalue;
                    break;
                case ProgNodeValueType.STRING:
                    value = int.Parse(svalue);
                    break;
                case ProgNodeValueType.BOOLEAN:
                    value = (bvalue) ? 1 : 0;
                    break;
            }

            return (value);
        }

        public string GetString()
        {
            string value = "";

            switch (Type)
            {
                case ProgNodeValueType.FLOAT:
                    value = fvalue.ToString();
                    break;
                case ProgNodeValueType.INTEGER:
                    value = ivalue.ToString();
                    break;
                case ProgNodeValueType.STRING:
                    value = svalue;
                    break;
                case ProgNodeValueType.BOOLEAN:
                    value = (bvalue) ? Constant.TRUE : Constant.FALSE;
                    break;
            }

            return (value);
        }

        public bool GetBoolean()
        {
            bool value = false;

            switch (Type)
            {
                case ProgNodeValueType.FLOAT:
                    value = (fvalue > 0.0f);
                    break;
                case ProgNodeValueType.INTEGER:
                    value = (ivalue > 0);
                    break;
                case ProgNodeValueType.STRING:
                    value = Constant.TRUE.Equals(svalue);
                    break;
                case ProgNodeValueType.BOOLEAN:
                    value = bvalue;
                    break;
            }

            return (value);
        }
    }
}