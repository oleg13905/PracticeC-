using System;

namespace ObratniyPorydok
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("while");
            int i = 80;
            while (i >= 10)
            {
                Console.WriteLine(i);
                i = i - 2;
            }

            Console.WriteLine("\ndo while");
            i = 80;
            do
            {
                Console.WriteLine(i);
                i = i - 2;
            } while (i >= 10);

            Console.WriteLine("\nfor");
            for (int j = 80; j >= 10; j = j - 2)
            {
                Console.WriteLine(j);
            }
        }
    }
}
