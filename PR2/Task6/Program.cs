using System;

namespace ZhivotnoePoGodu
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());

            int animalIndex = (year - 4) % 12;

            switch (animalIndex)
            {
                case 0:
                    Console.WriteLine("Крыса");
                    break;
                case 1:
                    Console.WriteLine("Бык");
                    break;
                case 2:
                    Console.WriteLine("Тигр");
                    break;
                case 3:
                    Console.WriteLine("Кролик");
                    break;
                case 4:
                    Console.WriteLine("Дракон");
                    break;
                case 5:
                    Console.WriteLine("Змея");
                    break;
                case 6:
                    Console.WriteLine("Лошадь");
                    break;
                case 7:
                    Console.WriteLine("Коза");
                    break;
                case 8:
                    Console.WriteLine("Обезьяна");
                    break;
                case 9:
                    Console.WriteLine("Петух");
                    break;
                case 10:
                    Console.WriteLine("Собака");
                    break;
                case 11:
                    Console.WriteLine("Свинья");
                    break;
            }
        }
    }
}
