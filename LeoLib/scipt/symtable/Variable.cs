using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.scipt.symtable
{
    class Variable
    {
        public string name { get; set; } = null;

        private float[] fvalue = null;
        private int[] ivalue = null;
        private string[] svalue = null;
        private bool[] bvalue = null;
    }
}
