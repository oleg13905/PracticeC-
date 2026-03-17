using System;

namespace TwoDigitProduct
{
    class Program
    {
        static void Main()
        {
            int number, firstDigit, secondDigit, product;

            Console.Write("Введите двузначное число = ");
            number = int.Parse(Console.ReadLine());

            firstDigit = number / 10;
            secondDigit = number % 10;
            product = firstDigit * secondDigit;

            Console.WriteLine();
            Console.WriteLine($"Произведение цифр: {firstDigit} * {secondDigit} = {product}");
        }
    }
}
