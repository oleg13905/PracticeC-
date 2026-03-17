using System;

namespace ZCalculation
{
    class Program
    {
        static void Main()
        {
            double alphaDegrees, alphaRadians;
            double z1, z2;

            Console.Write("Угол a (градусы) -> ");
            alphaDegrees = double.Parse(Console.ReadLine());
            alphaRadians = alphaDegrees * Math.PI / 180.0;

            z1 = (1 - Math.Pow(Math.Sin(alphaRadians), 2)) / (1 + Math.Pow(Math.Sin(2 * alphaRadians), 2));
            z2 = 1 / (1 + Math.Tan(alphaRadians));

            Console.WriteLine();
            Console.WriteLine($"a = {alphaDegrees:F1}° ({alphaRadians:F3} рад)");
            Console.WriteLine($"z1 = {z1:F6}");
            Console.WriteLine($"z2 = {z2:F6}");
            Console.WriteLine($"Разность: {Math.Abs(z1 - z2):F6}");
        }
    }
}
