using Delegate_Exercise_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Exercise3
{
    internal class Alarm
    {
        private int AlarmValue { get; set; }
        public Alarm(int alarmvalue)
        {
            AlarmValue = alarmvalue;
        }

        public void SetAlarmValue(int alarm)
        {
            AlarmValue = alarm;
        }
        public void Subscribe(Broker broker)
        {
            broker.Subscibe("TempratureChanged", FireAlarm);
        }
        public void FireAlarm( TempArgs args)
        {
            if (args.Temprature>AlarmValue)
            {
                Console.WriteLine($"Take care, The temprature value {args.Temprature} is grater than {AlarmValue} ");
            }
        }
    }
}
