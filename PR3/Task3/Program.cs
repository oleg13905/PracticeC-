using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N (размер матрицы, N<10): ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Введите a (начало диапазона): ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите b (конец диапазона): ");
            int b = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, N];
            Random rand = new Random();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = rand.Next(a, b + 1);
                }
            }

            Console.WriteLine("Исходная матрица " + N + "x" + N + ":");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int sumNegative = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        sumNegative += matrix[i, j];
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Сумма отрицательных элементов: " + sumNegative);

            Console.WriteLine("Количество четных элементов в строках:");
            for (int i = 0; i < N; i++)
            {
                int evenCount = 0;
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] % 2 == 0)
                    {
                        evenCount++;
                    }
                }
                Console.WriteLine((i + 1) + " строка: " + evenCount + " четных");
            }
        }
    }
}
