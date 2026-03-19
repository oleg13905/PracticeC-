using System;
using System.Text.RegularExpressions;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите email: ");
            string email = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isValid = Regex.IsMatch(email, pattern);

            Console.WriteLine("Корректный email: " + isValid);
        }
    }
}
