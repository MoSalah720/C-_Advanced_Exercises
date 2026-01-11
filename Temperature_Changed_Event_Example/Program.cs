namespace Temperature_Changed_Event_Example
{
    public class TemperatureChangedArgs : EventArgs 
    {
        public double OldTemperature {  get; set; }
        public double NewTemperature { get; set; }
        public double Differance { get; set; }

        public TemperatureChangedArgs(double oldtemperature , double newtemperature)
        {
            OldTemperature = oldtemperature;
            NewTemperature = newtemperature;
            Differance = NewTemperature - OldTemperature;
        }
    }

    public class ThermoState
    {
        public event EventHandler<TemperatureChangedArgs> TemperatureChanged;

        private double CurrentTemperature;
        private double OldTemperature;

        public void SetNewTemperature(double NewTemperature)
        {
            if (NewTemperature !=CurrentTemperature)
            {
                OldTemperature = CurrentTemperature;
                CurrentTemperature = NewTemperature;

                onTemperatureChanged(OldTemperature, NewTemperature);
            }
        }

        private void onTemperatureChanged(double OldTemperature, double NewTemperature)
        {
            onTemperatureChanged(new TemperatureChangedArgs(OldTemperature, NewTemperature));
        }

        protected virtual void onTemperatureChanged(TemperatureChangedArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }
    

    public class Display
    {
        public void Subscribe(ThermoState thermoState)
        {
            thermoState.TemperatureChanged += HandleTempChanged;
        }

        public void HandleTempChanged(object  sender, TemperatureChangedArgs e)
        {
            Console.WriteLine("\n\n Temperature Changed");
            Console.WriteLine($"Old Temperature = {e.OldTemperature}");
            Console.WriteLine($"New Temperature = {e.NewTemperature}");
            Console.WriteLine($"The Differance  = {e.Differance}");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            ThermoState thermoState =new ThermoState();
            Display display = new Display();

            display.Subscribe(thermoState);
            
            thermoState.SetNewTemperature(30);

            thermoState.SetNewTemperature(25);
            
            thermoState.SetNewTemperature(25); //nothing happened
        }
    }
}
