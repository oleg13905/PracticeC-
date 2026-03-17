using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            double x = 5.2;

            double inner = Math.Pow(x * x + 5, 2);
            double y = Math.Pow(Math.Sin(inner), 3) - Math.Sqrt(x / 4.0);

            Console.WriteLine($"При x = {x}, значение функции y = {y:F2}");
        }
    }
}
