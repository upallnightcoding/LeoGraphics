using LeoLib.game;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    abstract class ProgNode
    {
        public bool IsOK { get; set; } = true;

        private List<ErrorCode> errorList = null;

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        abstract public ProgNodeValue Evaluate();

        /************************/
        /*** Public Functions ***/
        /************************/

        public ProgNode()
        {
            IsOK = true;
            errorList = new List<ErrorCode>();
        }

        public void Error(ErrorCode code)
        {
            IsOK = false;
            errorList.Add(code);
        }
    }
}
