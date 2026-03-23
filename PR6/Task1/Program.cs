using System;

namespace Task1
{

    abstract class Animal
    {
        public abstract void MakeSound();
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Собака: Гав!");
        }
    }

    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Кот: Мяу!");
        }
    }

    class Cow : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Корова: Му!");
        }
    }

    class Program
    {
        static void Main()
        {
            Animal[] animals = {
            new Dog(),
            new Cat(),
            new Cow(),
        };

            Console.WriteLine("Звуки животных:");
            for (int i = 0; i < animals.Length; i++)
            {
                animals[i].MakeSound();
            }
        }
    }
}