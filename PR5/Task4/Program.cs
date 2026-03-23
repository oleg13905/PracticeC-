using System;

namespace Task4
{
    static class IntExtensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(4.IsEven());
            Console.WriteLine(7.IsEven());
            Console.WriteLine(0.IsEven());
            Console.WriteLine(10.IsEven());
        }
    }
}