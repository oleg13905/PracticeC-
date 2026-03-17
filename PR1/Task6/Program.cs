using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            double x = 5.0;

            double y = Math.Exp(2 * x)
                       - Math.Exp(Math.Sqrt(Math.Abs(1 - x)))
                       + (2 * Math.Pow(Math.Sin(x), 2)) / (Math.PI * Math.Pow(x, 2));

            Console.WriteLine($"При x = {x}, значение функции y = {y:F3}");
        }
    }
}
