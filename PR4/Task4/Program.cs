using System;

namespace Task4
{

    class Store
    {
        Order[] orders;

        public Store(Order[] o)
        {
            orders = o;
        }

        public Order[] HighValue(decimal min)
        {
            int cnt = 0;
            for (int i = 0; i < orders.Length; i++)
                if (orders[i].sum > min) cnt++;

            Order[] res = new Order[cnt];
            int k = 0;
            for (int i = 0; i < orders.Length; i++)
                if (orders[i].sum > min)
                {
                    res[k] = orders[i];
                    k++;
                }
            return res;
        }

        public Order[] ByCustomer(string name)
        {
            int cnt = 0;
            for (int i = 0; i < orders.Length; i++)
                if (orders[i].cust == name) cnt++;

            Order[] res = new Order[cnt];
            int k = 0;
            for (int i = 0; i < orders.Length; i++)
                if (orders[i].cust == name)
                {
                    res[k] = orders[i];
                    k++;
                }
            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            Order[] orders = {
            new Order(1, "Багдюн О.В.", 1500),
            new Order(2, "Петров Р.Е.", 5000),
            new Order(3, "Дубровский Р.В.", 2500),
            new Order(4, "Король К.А.", 300)
        };

            Store shop = new Store(orders);

            Console.WriteLine("Дорогие заказы (>2000):");
            Order[] high = shop.HighValue(2000);
            for (int i = 0; i < high.Length; i++)
                Console.WriteLine(high[i].id + " " + high[i].cust + " " + high[i].sum);

            Console.WriteLine("\nЗаказы Петрова Р.Е.:");
            Order[] ivanov = shop.ByCustomer("Петров Р.Е.");
            for (int i = 0; i < ivanov.Length; i++)
                Console.WriteLine(ivanov[i].id + " " + ivanov[i].sum);
        }
    }
}