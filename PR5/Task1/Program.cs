using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int[] arr = { 1, 5, 3, 9, 2 };
            int sum = ArraySum(arr);

            Console.WriteLine("Массив: " + string.Join(", ", arr));
            Console.WriteLine("Сумма: " + sum);
        }

        static int ArraySum(int[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }
    }
}