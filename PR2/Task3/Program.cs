using System;

namespace VozrastanieChisel
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("A = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("B = ");
            int b = int.Parse(Console.ReadLine());

            int n = 0;

            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
                n++;
            }

            Console.WriteLine($"Количество чисел N = {n}");

            Console.ReadKey();
        }
    }
}
