using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Введите высоту h (м): ");
            double height = double.Parse(Console.ReadLine());

            const double g = 9.81523;
            double time = Math.Sqrt(2 * height / g);

            Console.WriteLine($"Время падения t = {time:F3} с");
        }
    }
}
