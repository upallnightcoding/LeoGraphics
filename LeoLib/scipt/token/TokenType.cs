using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public enum TokenType
    {
        UNKNOWN,

        COMPLEX,
        BOTTOM_EXP_STACK,
        ASSIGN,
        KEYWORD,

        // Constant & Variable Types
        //--------------------------
        STRING,
        BOOLEAN,
        INTEGER,
        FLOAT,

        // Token Breaks & Characters
        //--------------------------
        EOS,
        EOF,
        EXP_SEPARATOR,

        // Binary Operators
        //-----------------
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE,
        MODULUS,
        POWER,

        // Logical Operators
        //------------------
        LT,
        LE,
        GT,
        GE,
        NOT,
        NE,

        // Left and Right Parenthesis
        //---------------------------
        LEFT_PAREN,
        RIGHT_PAREN
    }
}
