using System;

namespace TabulationFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = Math.PI / 4;
            double B = Math.PI / 2;
            int M = 15;

            double H = (B - A) / M;

            Console.WriteLine("Табулирование функции 2 - sin(x)");
            Console.WriteLine("Отрезок [{0:F2}, {1:F2}]", A, B, M + 1);
            Console.WriteLine("H = {0:F2}", H);

            double x = A;
            for (int i = 0; i <= M; i++)
            {
                double y = 2 - Math.Sin(x);
                Console.WriteLine("{0,3} {1,7:F3} {2,7:F3}", i, x, y);
                x = x + H;
            }
        }
    }
}