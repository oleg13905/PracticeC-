using System;

namespace Task1
{

    delegate double MathOperation(double x, double y);

    class Addition
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Multiplication
    {
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
    }

    class Program
    {
        static void Main()
        {
            MathOperation add = Addition.Add;
            MathOperation multiply = Multiplication.Multiply;

            Console.WriteLine("5 + 3 = " + add(5, 3));
            Console.WriteLine("5 * 3 = " + multiply(5, 3));
            Console.WriteLine("7 + 4 = " + add(7, 4));
            Console.WriteLine("7 * 4 = " + multiply(7, 4));
        }
    }
}