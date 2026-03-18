using System;

namespace MassKg
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Введите массу в килограммах: ");
            double massKg = double.Parse(Console.ReadLine());

            int fullCentners = (int)(massKg / 100.0);

            Console.WriteLine($"Полных центнеров: {fullCentners}");
        }
    }
}
