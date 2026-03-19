using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[50];

            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = random.Next(1, 101);
            }

            int lastNumber = numbers[49];
            int differentCount = 0;

            Console.WriteLine($"Последнее число: {lastNumber}");
            Console.WriteLine();

            for (int index = 0; index < numbers.Length; index++)
            {
                Console.Write($"{numbers[index],3} ");
                if (numbers[index] != lastNumber)
                {
                    differentCount++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Отличных от последнего: {differentCount}");
        }
    }
}
