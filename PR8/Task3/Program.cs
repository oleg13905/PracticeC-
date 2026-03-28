using System;

namespace Task3
{
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    class BankAccount
    {
        private decimal balance = 1000.50m;

        public decimal Balance => balance;

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
                throw new InsufficientFundsException($"Недостаточно средств");

            balance -= amount;
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();
            decimal[] amounts = { 500.00m, 600.00m, 1200.00m };

            foreach (decimal amount in amounts)
            {
                try
                {
                    Console.WriteLine($"Баланс: {account.Balance:F2}");
                    account.Withdraw(amount);
                    Console.WriteLine("OK");
                }
                catch (InsufficientFundsException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}