using System;
using System.Collections.Generic;
using System.Text;

namespace LeoLib.script
{
    public class Number
    {
        public int value;
        private int n;

        public Number(int value, int n)
        {
            this.value = value;
            this.n = n;
        }

        public int getAsWholeNumber()
        {
            return (value);
        }

        public float getAsFractional()
        {
            return((float)(value / Math.Pow(10.0, n)));
        }
    }
}
