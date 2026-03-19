using System;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();

            string[] words = text.Split(' ', ',', '.', '!', '?', ';', ':');
            int maxCount = 0;
            string maxWord = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "") continue;

                int count = 0;
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[i] == words[j])
                        count++;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxWord = words[i];
                }
            }

            Console.WriteLine("Чаще всего: '" + maxWord + "' (" + maxCount + ")");
        }
    }
}
