using Delegate_Exercise_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Exercise3
{
    internal class Sensor
    {
        //public event EventHandler<TempArgs> SensorChanged;
        private Broker _broker;
        public Sensor( Broker broker)
        {
            _broker = broker;
        }
        private int CurrentTemperature { get; set; }

        public void ChangeTemprature(int NewTemprature)
        {
            CurrentTemperature = NewTemprature;

            _broker.Publish("TempratureChanged", new TempArgs(NewTemprature));
            //SensorChanged.Invoke(this,new TempArgs (NewTempratue));


        }
    }
}
