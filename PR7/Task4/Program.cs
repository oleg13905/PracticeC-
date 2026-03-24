using System;

namespace Task4
{
    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }

        public TemperatureEventArgs(double temp)
        {
            Temperature = temp;
        }
    }

    class TemperatureSensor
    {
        public event EventHandler<TemperatureEventArgs> TemperatureChanged;

        public void SetTemperature(double temp)
        {
            Console.WriteLine($"Температура: {temp}°C");
            TemperatureChanged?.Invoke(this, new TemperatureEventArgs(temp));
        }
    }

    class TemperatureMonitor
    {
        public TemperatureMonitor(TemperatureSensor sensor)
        {
            sensor.TemperatureChanged += CoolingSystem.OnTemperatureChanged;
            sensor.TemperatureChanged += AlarmSystem.OnTemperatureChanged;
        }
    }

    class CoolingSystem
    {
        public static void OnTemperatureChanged(object sender, TemperatureEventArgs e)
        {
            if (e.Temperature > 25)
            {
                Console.WriteLine("Кондиционер включен");
            }
        }
    }

    class AlarmSystem
    {
        public static void OnTemperatureChanged(object sender, TemperatureEventArgs e)
        {
            if (e.Temperature > 30)
            {
                Console.WriteLine("Перегрев!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TemperatureSensor sensor = new TemperatureSensor();

            TemperatureMonitor monitor = new TemperatureMonitor(sensor);

            sensor.SetTemperature(22);
            sensor.SetTemperature(27);
            sensor.SetTemperature(32);
        }
    }
}