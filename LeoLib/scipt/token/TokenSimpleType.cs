using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.token
{
    public enum TokenSimpleType
    {
        UNKNOWN,
        EOS,
        EXP_SEPARATOR,
        POWER,
        MODULUS,
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE,
        BOTTOM_EXP_STACK,
        ASSIGN,
        LEFT_PAREN,
        RIGHT_PAREN
    }
}
