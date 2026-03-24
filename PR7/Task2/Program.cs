using System;

namespace Task2
{

    delegate double MathOperation(double x, double y);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("7 + 3 = " + Calculate(7, 3, Add));
            Console.WriteLine("7 * 3 = " + Calculate(7, 3, Multiply));
            Console.WriteLine("9 - 4 = " + Calculate(9, 4, Subtract));
        }

        static double Calculate(double x, double y, MathOperation operation)
        {
            return operation(x, y);
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }
    }
}