using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("c = ");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");
           
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
