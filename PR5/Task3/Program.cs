using System;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.Write("N= ");
            int n = int.Parse(Console.ReadLine());

            long[] fib = new long[n + 1];

            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            Console.WriteLine("F(" + n + ") = " + fib[n]);

            Console.Write("Вся последовательность: ");
            for (int i = 0; i <= n; i++)
            {
                Console.Write(fib[i] + " ");
            }
            Console.WriteLine();
        }
    }
}