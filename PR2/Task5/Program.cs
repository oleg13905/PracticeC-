using System;

namespace ChetnieChisla
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("Число четное");
            }
            else
            {
                Console.WriteLine("Число нечетное");
            }

            Console.ReadKey();
        }
    }
}
