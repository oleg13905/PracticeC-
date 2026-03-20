using System;

namespace Task3
{
    abstract class BankAccount
    {
        public string num;
        public decimal bal;
        public string name;

        public BankAccount(string n, decimal b, string nm)
        {
            num = n;
            bal = b;
            name = nm;
        }

        public abstract void Put(decimal x);
        public abstract bool Take(decimal x);
    }

    sealed class SaveAcc : BankAccount
    {
        public SaveAcc(string n, decimal b, string nm) : base(n, b, nm) { }

        public override void Put(decimal x) { if (x > 0) bal += x; }
        public override bool Take(decimal x) { if (x > 0 && x <= bal) { bal -= x; return true; } return false; }
    }

    sealed class CheckAcc : BankAccount
    {
        decimal limit = 1000;

        public CheckAcc(string n, decimal b, string nm) : base(n, b, nm) { }

        public override void Put(decimal x) { if (x > 0) bal += x; }
        public override bool Take(decimal x) { if (x > 0 && bal - x >= -limit) { bal -= x; return true; } return false; }
    }

    class Bank
    {
        BankAccount[] accs;

        public Bank(BankAccount[] a) { accs = a; }

        public string Richest()
        {
            if (accs.Length == 0) return "нет счетов";
            BankAccount max = accs[0];
            for (int i = 1; i < accs.Length; i++)
                if (accs[i].bal > max.bal) max = accs[i];
            return max.name + " " + max.num;
        }

        public decimal Total()
        {
            decimal s = 0;
            for (int i = 0; i < accs.Length; i++)
                s += accs[i].bal;
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount[] accounts = {
            new SaveAcc("S1", 50000, "Багдюн О.В."),
            new CheckAcc("C1", 25000, "Петров Е.В."),
            new SaveAcc("S2", 75000, "Дубровский Р.В.")
        };

            Bank b = new Bank(accounts);

            Console.WriteLine("Богатейший: " + b.Richest());
            Console.WriteLine("Всего: " + b.Total());
        }
    }
}