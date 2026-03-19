using System;

namespace Task6
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();

            bool hasDigit = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    hasDigit = true;
                    break;
                }
            }

            Console.WriteLine("Есть цифры: " + hasDigit);
        }
    }
}