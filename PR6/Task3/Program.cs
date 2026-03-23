using System;

namespace Task3
{

    class Vehicle
    {
        public string Model;
        public int Year;

        public Vehicle(string model, int year)
        {
            Model = model;
            Year = year;
        }
    }

    interface IElectric
    {
        void Charge();
    }

    interface IDiesel
    {
        void RefuelDiesel();
    }

    class ElectricCar : Vehicle, IElectric
    {
        public ElectricCar(string model, int year) : base(model, year) { }

        public void Charge()
        {
            Console.WriteLine(Model + " заряжается от сети");
        }
    }

    class Truck : Vehicle, IDiesel
    {
        public Truck(string model, int year) : base(model, year) { }

        public void RefuelDiesel()
        {
            Console.WriteLine(Model + " заправляется дизелем");
        }
    }

    class Program
    {
        static void Main()
        {
            Vehicle[] vehicles = {
            new ElectricCar("Tesla Model 3", 2023),
            new Truck("Audi Q6", 2010),
            new ElectricCar("Nissan Leaf", 2021),
            new Truck("BMW X5 E73", 2018),
            new ElectricCar("BMW i4", 2023)
        };

            Console.WriteLine("Дизельные машины:");
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is IDiesel)
                {
                    IDiesel diesel = (IDiesel)vehicles[i];
                    Console.WriteLine(vehicles[i].Model + " (" + vehicles[i].Year + ")");
                    diesel.RefuelDiesel();
                }
            }
        }
    }
}