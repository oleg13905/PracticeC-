using System;

namespace Task1
{
    class A
    {
        int a;
        int b;

        public A(int x, int y)
        {
            a = x;
            b = y;
        }

        public int Difference()
        {
            return a - b;
        }

        public double Expression()
        {
            return (a + b) / (double)(a - b);
        }

        public void Show()
        {
            Console.WriteLine("a = " + a + ", b = " + b);
        }
    }

    class Program
    {
        static void Main()
        {
            A obj = new A(10, 3);

            obj.Show();
            Console.WriteLine("Разность a-b: " + obj.Difference());
            Console.WriteLine("(a+b)/(a-b): "+ obj.Expression());
        }
    }
}