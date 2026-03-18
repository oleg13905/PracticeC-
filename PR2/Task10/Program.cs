using System;

namespace AutomorphicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Трехзначные автоморфные числа:");

            for (int i = 100; i <= 999; i++)
            {
                long square = (long)i * i;
                int lastDigits = (int)(square % 1000);

                if (lastDigits == i)
                {
                    Console.WriteLine("{0} * {0} = {1}", i, square);
                }
            }
        }
    }
}