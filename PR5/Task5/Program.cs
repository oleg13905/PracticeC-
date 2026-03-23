using System;

namespace Task5
{
    abstract class Animal
    {
        public abstract void MakeSound();

        public virtual void Sleep()
        {
            Console.WriteLine("Животное спит");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("ГАВВ!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Собака спит на полу");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("МЯУУ!");
        }

        public override void Sleep()
        {
            Console.WriteLine("Кот спит на кровати");
        }
    }

    class Program
    {
        static void Main()
        {
            Animal dog = new Dog();
            Animal cat = new Cat();

            dog.MakeSound();
            dog.Sleep();

            Console.WriteLine();

            cat.MakeSound();
            cat.Sleep();
        }
    }
}