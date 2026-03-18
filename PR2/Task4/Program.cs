using System;

namespace VichislenieUrovnenia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление значения функции:");
            Console.WriteLine("y = 4 + x² - e^(√x) при x >= 10");
            Console.WriteLine("y = 3,4 - x + 0,1x³ при x < 10\n");

            Console.Write("Введите значение x: ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double x))
            {
                Console.WriteLine("Ошибка: необходимо ввести число");
                Console.ReadKey();
                return;
            }

            double y;

            if (x >= 10)
            {
                y = 4 + (x * x) - Math.Exp(Math.Sqrt(x));
            }
            else
            {
                y = 3.4 - x + 0.1 * (x * x * x);
            }

            Console.WriteLine($"Результат: y = {y:F4}");

            Console.WriteLine("\nДля завершения нажмите любую клавишу. . .");
            Console.ReadKey();
        }
    }
}