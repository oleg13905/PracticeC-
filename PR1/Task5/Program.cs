using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Введите четырёхзначное число: ");
            int number = int.Parse(Console.ReadLine());

            int d1 = number / 1000;
            int d2 = (number / 100) % 10;
            int d3 = (number / 10) % 10;
            int d4 = number % 10;

            int product = d1 * d2 * d3 * d4;

            Console.WriteLine($"Произведение цифр числа {number} равно {product}.");
        }
    }
}
