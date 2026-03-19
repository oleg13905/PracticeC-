using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = { 1.8, 2.3, -0.13, 4.1, 0.0, 3.9 };

            Console.WriteLine("Массив вещественных чисел:");
            Console.WriteLine();

            double sum = 0.0;
            int elementCount = 0;

            for (int index = 0; index < numbers.Length; index++)
            {
                Console.WriteLine($"{index,2}  {numbers[index],8:F2}");
                sum += numbers[index];
                elementCount++;
            }

            Console.WriteLine();
            Console.WriteLine($"Количество элементов: {elementCount}");
            Console.WriteLine($"Сумма элементов: {sum:F2}");
        }
    }
}
