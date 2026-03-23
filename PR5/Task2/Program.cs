using System;

namespace Task2
{
    class  Program
    {
        static void Main()
        {
            double a1 = 2.5, b1, c1, d1;
            double a2 = 1.8, b2, c2, d2;
            double a3 = 3.2, b3, c3, d3;
            double a4 = 0.7, b4, c4, d4;
            double a5 = 4.1, b5, c5, d5;
       
            Console.WriteLine("Число A   B=A^2   C=A^3   D=A^4");

            PowerA234(a1, out b1, out c1, out d1);
            Console.WriteLine("{0,8:F1} {1,8:F1} {2,8:F1} {3,8:F1}", a1, b1, c1, d1);

            PowerA234(a2, out b2, out c2, out d2);
            Console.WriteLine("{0,8:F1} {1,8:F1} {2,8:F1} {3,8:F1}", a2, b2, c2, d2);

            PowerA234(a3, out b3, out c3, out d3);
            Console.WriteLine("{0,8:F1} {1,8:F1} {2,8:F1} {3,8:F1}", a3, b3, c3, d3);

            PowerA234(a4, out b4, out c4, out d4);
            Console.WriteLine("{0,8:F1} {1,8:F1} {2,8:F1} {3,8:F1}", a4, b4, c4, d4);

            PowerA234(a5, out b5, out c5, out d5);
            Console.WriteLine("{0,8:F1} {1,8:F1} {2,8:F1} {3,8:F1}", a5, b5, c5, d5);
        }

        static void PowerA234(double a, out double b, out double c, out double d)
        {
            b = a * a;
            c = b * a;
            d = c * a;
        }
    }
}