using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Размер матрицы N = ");
            int n = int.Parse(Console.ReadLine());

            int[,] arr = new int[n, n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arr[i, j] = r.Next(-20, 21);

            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }

            Console.Write("Номер строки (0-{0}): ", n - 1);
            int row = int.Parse(Console.ReadLine());

            Console.Write("Заданное число: ");
            int limit = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int j = 0; j < n; j++)
                sum += arr[row, j];

            Console.WriteLine("Сумма строки {0}: {1}", row, sum);
            Console.WriteLine("Сумма > {0}: {1}", limit, sum > limit);
        }
    }
}
