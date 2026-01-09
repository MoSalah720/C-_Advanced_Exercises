using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Exercise3
{
    internal class TempArgs :EventArgs
    { 
        public int Temprature {  get; set; }

        public TempArgs(int Temp)
        {
            Temprature = Temp;
        }

    }
}
