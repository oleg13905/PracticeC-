using System;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            string inputText = Console.ReadLine();

            StringBuilder textBuilder = new StringBuilder();
            textBuilder.Append(inputText);

            Console.Write("Добавить строку: ");
            string newLine = Console.ReadLine();
            textBuilder.Append(newLine);

            Console.WriteLine("Результат: " + textBuilder.ToString());
        }
    }
}
