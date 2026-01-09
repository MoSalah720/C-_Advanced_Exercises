using Delegate_Exercise_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Exercise3
{
    internal class Display
    {
        public void Subscribe(Broker broker)
        {
            broker.Subscibe("TempratureChanged", ShowTemprature);
        }
        public void ShowTemprature( TempArgs args)
        {
            Console.WriteLine($"The temprature is {args.Temprature} from display");
        }
    }
}
