using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    class Constant
    {
        // Token Character Constants
        //--------------------------
        public const char EOS = ';';
        public const char EXP_SEPARATOR = ',';
        public const char STRING_CHARACTER = '"';
        public const char FRACTIONAL_DOT = '.';
        public const string SIMPLE_TOKENS = "+-*/,;()=";

        // True or False Constants
        //------------------------
        public const string TRUE = "TRUE";
        public const string FALSE = "FALSE";

        public const int NUMBER_OF_SCRIPT_TYPES = 4;

        public const int MAX_SYMBOL_TABLE_SCOPE = 10;

        // Command Names
        //--------------
        public const string CMD_END = "END";

        // Shader texture and position layout names
        //-----------------------------------------
        public const string SHADER_POSITION = "aPosition";
        public const string SHADER_TEXCOORD = "aTexCoord";

        // Shader Uniform Names
        //---------------------
        public const string SHADER_UNIFORM_MODEL = "model";
        public const string SHADER_UNIFORM_VIEW = "view";
        public const string SHADER_UNIFORM_PROJECTION = "projection";

        public const string SHADER_VERT = 
            @"D:\Application\cs\LeoGraphics\Leo\LeoLib\glsl\shader2D.vert";
        public const string SHADER_FRAG = 
            @"D:\Application\cs\LeoGraphics\Leo\LeoLib\glsl\shader2D.frag";
        public const string RESOURCE = 
            @"D:\Application\cs\LeoGraphics\Leo\Client\resources\";
    }
}
