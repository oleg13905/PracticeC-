using System;

namespace CylinderVolume
{
    class Program
    {
        static void Main()
        {
            double radius, height, volume;

            Console.WriteLine("Вычисление объема цилиндра");
            Console.WriteLine();
            Console.WriteLine("Введите исходные данные:");

            Console.Write("Радиус основания (см) = ");
            radius = double.Parse(Console.ReadLine());

            Console.Write("Высота цилиндра (см) = ");
            height = double.Parse(Console.ReadLine());

            volume = Math.PI * radius * radius * height;

            Console.WriteLine();
            Console.WriteLine($"Объем цилиндра {volume:F2} куб. см.");
        }
    }
}
