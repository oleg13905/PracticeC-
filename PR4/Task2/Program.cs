using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Person(Name='{Name}', Age={Age})";
        }
    }

    public static class ArrayUtils
    {
        public static Person[] SortByName(Person[] people)
        {
            var sorted = people.OrderBy(p => p.Name).ToArray();
            return sorted;
        }

        public static Person[] GeneratePersons(int count)
        {
            string[] names = { "Алиса", "Борис", "Варя", "Глеб", "Дмитрий" };
            Random rand = new Random();

            Person[] persons = new Person[count];
            for (int i = 0; i < count; i++)
            {
                string name = names[rand.Next(names.Length)];
                int age = rand.Next(18, 65);
                persons[i] = new Person(name, age);
            }
            return persons;
        }

        public static void PrintPersons(Person[] people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Person[] persons = ArrayUtils.GeneratePersons(5);

            Console.WriteLine("До сортировки:");
            ArrayUtils.PrintPersons(persons);

            Person[] sortedPersons = ArrayUtils.SortByName(persons);

            Console.WriteLine("\nПосле сортировки по имени:");
            ArrayUtils.PrintPersons(sortedPersons);
        }
    }
}