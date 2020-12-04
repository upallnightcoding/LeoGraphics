using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.game
{
    class SystemMsg
    {
        private static SystemMsg INSTANCE = null;

        private readonly Dictionary<ErrorCode, string> errorMsg = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        private SystemMsg()
        {
            errorMsg = new Dictionary<ErrorCode, string>();

            PopulateErrors();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public static SystemMsg GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SystemMsg();
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
                "Expecting either a comma or end of statement token in this statement";
        }
    }
}
