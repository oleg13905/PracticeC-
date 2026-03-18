using System;

namespace Chetverti
{
    internal class Program
    {
        private static void Main()
        {
            double x;
            double y;

            Console.Write("x = ");
            x = double.Parse(Console.ReadLine());

            Console.Write("y = ");
            y = double.Parse(Console.ReadLine());

            if (x < 0 && y > 0)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }
        }
    }
}
