using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    class Constant
    {
        // Token Character Constants
        //--------------------------
        public static char EOS = ';';
        public static char EXP_SEPARATOR = ',';
        public static char STRING_CHARACTER = '"';
        public static char FRACTIONAL_DOT = '.';
        public static string SIMPLE_TOKENS = "+-*/,;()";

        // True or False Constants
        //------------------------
        public static string TRUE = "TRUE";
        public static string FALSE = "FALSE";
    }
}
