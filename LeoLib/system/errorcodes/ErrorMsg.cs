using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game
{
    class ErrorMsg
    {
        private static ErrorMsg INSTANCE = null;

        private readonly Dictionary<ErrorCode, string> errorMsg = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        private ErrorMsg()
        {
            errorMsg = new Dictionary<ErrorCode, string>();

            PopulateErrors();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public static ErrorMsg GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ErrorMsg();
            }

            return (INSTANCE);
        }

        public string GetMsg(ErrorCode code)
        {
            return (errorMsg[code]);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void PopulateErrors()
        {
            errorMsg[ErrorCode.ERROR_COMMA_OR_EOS] = 
                "Expecting either a comma or end of statement token in this statement.";
            errorMsg[ErrorCode.ERROR_UNKNOWN_COMMAND] =
                "The command used for this statement is not supported.";
        }
    }
}
