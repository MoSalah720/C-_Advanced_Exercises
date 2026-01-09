using Delegate_Exercise_3;
using System.Runtime.InteropServices.Swift;

namespace Delegate_Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sensor Adjust Temp
            // Display
            // Alarm

            Broker broker = new Broker();

            Sensor sensor = new Sensor(broker);//publisher


            //subscribers
            Display display = new Display();
            Alarm alarm =new Alarm(20);

            //subscribtion
            display.Subscribe(broker);
            alarm.Subscribe(broker);

            //sensor.SensorChanged += display.ShowTemprature;
            //sensor.SensorChanged += alarm.FireAlarm;


            while (true)
            {
                Console.WriteLine("Welcome to sensor temperature");
                Console.WriteLine("1. Set the temperature");
                Console.WriteLine("2. Set a new alarm value, the default is (20)");
                Console.WriteLine("3. Exist");

                var Result = Console.ReadLine();

                switch(Result)
                {
                    case "1":
                        Console.WriteLine("Please, Set the temprature");
                        var temp = Console.ReadLine();
                        int TempValue = Convert.ToInt32(temp);
                        sensor.ChangeTemprature(TempValue);
                        break;

                    case "2":
                        Console.WriteLine("Please, Set the alarm value ");
                        var AlarmString = Console.ReadLine();
                        int AlarmValue = Convert.ToInt32(AlarmString);
                        alarm.SetAlarmValue(AlarmValue);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("error ,wrong value");
                        break;

                }
            }
        }
    }
}
