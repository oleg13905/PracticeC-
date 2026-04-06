using System;

namespace Task2
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public class BasicCoffee : ICoffee
    {
        public string GetDescription() => "Черный кофе";
        public double GetCost() => 50;
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            this.coffee = coffee;
        }

        public virtual string GetDescription() => coffee.GetDescription();
        public virtual double GetCost() => coffee.GetCost();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => coffee.GetDescription() + ", молоко";
        public override double GetCost() => coffee.GetCost() + 10;
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => coffee.GetDescription() + ", сахар";
        public override double GetCost() => coffee.GetCost() + 5;
    }

    public class SyrupDecorator : CoffeeDecorator
    {
        private string syrupType;

        public SyrupDecorator(ICoffee coffee, string syrupType = "ванильный") : base(coffee)
        {
            this.syrupType = syrupType;
        }

        public override string GetDescription() => coffee.GetDescription() + $", сироп {syrupType}";
        public override double GetCost() => coffee.GetCost() + 15;
    }

    class Program
    {
        static void Main()
        {
            ICoffee coffee = new BasicCoffee();
            PrintCoffee("Обычный кофе", coffee);

            ICoffee coffeeWithMilk = new MilkDecorator(coffee);
            PrintCoffee("Кофе с молоком", coffeeWithMilk);

            ICoffee coffeeWithMilkAndSugar = new SugarDecorator(coffeeWithMilk);
            PrintCoffee("Кофе с молоком и сахаром", coffeeWithMilkAndSugar);

            ICoffee fullCoffee = new SyrupDecorator(coffeeWithMilkAndSugar, "карамельный");
            PrintCoffee("Кофе с молоком, сахаром и сиропом", fullCoffee);

            ICoffee customCoffee = new SyrupDecorator(new SugarDecorator(new MilkDecorator(new BasicCoffee())), "ореховый");
            PrintCoffee("Кастомный кофе", customCoffee);
        }

        static void PrintCoffee(string title, ICoffee coffee)
        {
            Console.WriteLine(title);
            Console.WriteLine("Описание: " + coffee.GetDescription());
            Console.WriteLine("Цена: " + coffee.GetCost() + " р");
            Console.WriteLine();
        }
    }
}