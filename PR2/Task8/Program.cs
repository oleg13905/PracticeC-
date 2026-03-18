using System;

namespace ZnachenieVirazhenia
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            double sum = 0.0;
            double sign = 1.0;

            for (int i = 1; i <= n; i++)
            {
                sum += sign * (1.0 + i / 10.0);
                sign = -sign;
            }

            Console.WriteLine($"Сумма = {sum:F4}");
            Console.ReadKey();
        }
    }
}
