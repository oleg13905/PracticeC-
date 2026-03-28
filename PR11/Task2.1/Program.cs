using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{

    public interface IFilterStrategy
    {
        IEnumerable<int> Filter(IEnumerable<int> data);
    }

    public class EvenNumberFilter : IFilterStrategy
    {
        public IEnumerable<int> Filter(IEnumerable<int> data)
        {
            return data.Where(x => x % 2 == 0);
        }

        public override string ToString() => "Четные числа";
    }

    public class PrimeNumberFilter : IFilterStrategy
    {
        public IEnumerable<int> Filter(IEnumerable<int> data)
        {
            return data.Where(IsPrime);
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public override string ToString() => "Простые числа";
    }

    public class RangeFilter : IFilterStrategy
    {
        private readonly int min, max;

        public RangeFilter(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public IEnumerable<int> Filter(IEnumerable<int> data)
        {
            return data.Where(x => x >= min && x <= max);
        }

        public override string ToString() => $"Диапазон [{min}-{max}]";
    }

    public class DataFilter
    {
        private IFilterStrategy strategy;

        public void SetStrategy(IFilterStrategy strategy)
        {
            this.strategy = strategy;
            Console.WriteLine($"Стратегия: {strategy}");
        }

        public IEnumerable<int> ApplyFilter(IEnumerable<int> data)
        {
            if (strategy == null)
            {
                Console.WriteLine("Стратегия не установлена!");
                return data;
            }
            return strategy.Filter(data);
        }
    }

    class Program
    {
        static void Main()
        {
            DataFilter filter = new DataFilter();
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 17 };

            Console.WriteLine("Исходные данные: " + string.Join(", ", data));

            filter.SetStrategy(new EvenNumberFilter());
            var evens = filter.ApplyFilter(data);
            Console.WriteLine("Результат: " + string.Join(", ", evens));

            filter.SetStrategy(new PrimeNumberFilter());
            var primes = filter.ApplyFilter(data);
            Console.WriteLine("Результат: " + string.Join(", ", primes));

            filter.SetStrategy(new RangeFilter(4, 8));
            var range = filter.ApplyFilter(data);
            Console.WriteLine("Результат: " + string.Join(", ", range));

            Console.WriteLine("\nДинамическое переключение");

            IFilterStrategy[] strategies = {
            new EvenNumberFilter(),
            new PrimeNumberFilter(),
            new RangeFilter(5, 10)
        };

            foreach (var strat in strategies)
            {
                filter.SetStrategy(strat);
                var result = filter.ApplyFilter(data);
                Console.WriteLine($"[{strat}]: {string.Join(", ", result)}");
            }
        }
    }
}