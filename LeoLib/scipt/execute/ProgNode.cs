using LeoLib.game;
using LeoLib.script.execute;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public abstract class ProgNode
    {
        public bool IsOK { get; set; } = true;

        private List<ErrorCode> errorList = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ProgNode()
        {
            errorList = new List<ErrorCode>();
            IsOK = true;
        }

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        abstract public ProgNodeValue Evaluate();

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Error(ErrorCode code)
        {
            IsOK = false;
            errorList.Add(code);
        }
    }
}
