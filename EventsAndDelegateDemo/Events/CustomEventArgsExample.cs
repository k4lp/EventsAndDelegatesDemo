namespace EventsAndDelegatesDemo.Events
{
    public class CustomEventArgsExample
    {
        public class TemperatureChangedEventArgs : EventArgs
        {
            public float NewTemperature { get; }

            public TemperatureChangedEventArgs(float newTemperature)
            {
                NewTemperature = newTemperature;
            }
        }

        public class Thermostat
        {
            private float currentTemperature;

            public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

            public float CurrentTemperature
            {
                get => currentTemperature;
                set
                {
                    if (currentTemperature != value)
                    {
                        currentTemperature = value;
                        OnTemperatureChanged(new TemperatureChangedEventArgs(currentTemperature));
                    }
                }
            }

            protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
            {
                TemperatureChanged?.Invoke(this, e);
            }
        }

        public static void Run()
        {
            Console.WriteLine("Custom EventArgs Example:");

            Thermostat thermostat = new Thermostat();
            thermostat.TemperatureChanged += Thermostat_TemperatureChanged!;

            Console.WriteLine("Changing temperature...");
            thermostat.CurrentTemperature = 20;
            thermostat.CurrentTemperature = 22.5f;
            thermostat.CurrentTemperature = 18.5f;

            Console.WriteLine();
        }

        private static void Thermostat_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Temperature changed to {e.NewTemperature}°C");
        }
    }
}