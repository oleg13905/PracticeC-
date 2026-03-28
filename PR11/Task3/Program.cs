using System;
using System.Collections.Generic;

namespace Task4
{

    public interface IStockObserver
    {
        void Update(string stockSymbol, double newPrice);
    }

    public class StockMarket
    {
        private List<IStockObserver> observers = new List<IStockObserver>();
        private Dictionary<string, double> prices = new Dictionary<string, double>();

        public void AddStock(string symbol, double price)
        {
            prices[symbol] = price;
        }

        public void Subscribe(IStockObserver observer)
        {
            observers.Add(observer);
            Console.WriteLine($"Подписчик {observer} добавлен");
        }

        public void Unsubscribe(IStockObserver observer)
        {
            observers.Remove(observer);
            Console.WriteLine($"Подписчик {observer} удален");
        }

        public void UpdatePrice(string symbol, double newPrice)
        {
            if (prices.ContainsKey(symbol))
            {
                prices[symbol] = newPrice;
                Console.WriteLine($"\nЦена {symbol} изменилась: {newPrice}");
                Notify(symbol, newPrice);
            }
        }

        private void Notify(string symbol, double price)
        {
            foreach (IStockObserver observer in observers.ToArray())
            {
                observer.Update(symbol, price);
            }
        }
    }

    public class Investor : IStockObserver
    {
        private string name;
        private List<string> watchedStocks;

        public Investor(string name, params string[] stocks)
        {
            this.name = name;
            this.watchedStocks = new List<string>(stocks);
        }

        public void Update(string symbol, double price)
        {
            if (watchedStocks.Contains(symbol))
            {
                Console.WriteLine($"{name}: Акция {symbol} теперь {price}");

                if (price > 100)
                {
                    Console.WriteLine($"{name}: ПРОДАЮ {symbol}!");
                }
                else if (price < 50)
                {
                    Console.WriteLine($"{name}: ПОКУПАЮ {symbol}!");
                }
            }
        }

        public override string ToString() => name;
    }

    class Program
    {
        static void Main()
        {
            StockMarket market = new StockMarket();

            Investor ivan = new Investor("Игорь", "AAPL", "GOOG");
            Investor olga = new Investor("Ксения", "AAPL", "MSFT");
            Investor petr = new Investor("Петр", "GOOG", "TSLA");

            market.AddStock("AAPL", 120);
            market.AddStock("GOOG", 80);
            market.AddStock("MSFT", 90);
            market.AddStock("TSLA", 200);

            market.Subscribe(ivan);
            market.Subscribe(olga);
            market.Subscribe(petr);

            market.UpdatePrice("AAPL", 110);
            market.UpdatePrice("GOOG", 75);
            market.UpdatePrice("MSFT", 95);

            Console.WriteLine("\n- Отписка Ксении -");
            market.Unsubscribe(olga);
            market.UpdatePrice("AAPL", 105);

            Console.WriteLine("\n- Массовое изменение -");
            market.UpdatePrice("TSLA", 180);
        }
    }
}