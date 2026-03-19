using System;

namespace Task5
{
    class Program
    {
        static void Main()
        {
            Console.Write("Строк: ");
            int n = int.Parse(Console.ReadLine());

            int[][] arr = new int[n][];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                Console.Write("Длина " + i + ": ");
                int len = int.Parse(Console.ReadLine());
                arr[i] = new int[len];

                for (int j = 0; j < len; j++)
                {
                    arr[i][j] = rnd.Next(-50, 50);
                }
            }

            int maxSum = 0;
            int maxRow = 0;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                Console.Write(i + " ");

                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                    sum += arr[i][j];
                }

                Console.WriteLine(" Сумма=" + sum);

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxRow = i;
                }
            }

            Console.WriteLine("Макс сумма в строке " + maxRow + " = " + maxSum);
        }
    }
}