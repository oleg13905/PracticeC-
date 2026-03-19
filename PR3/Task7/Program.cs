using System;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine();

            string resultString = string.Empty;

            for (int index = 0; index < inputString.Length; index++)
            {
                if (inputString[index] != ' ')
                {
                    resultString += inputString[index];
                }
            }

            Console.WriteLine("Строка без пробелов: " + resultString);
        }
    }
}
