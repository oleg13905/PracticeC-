using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class InvalidAccountNumberException : Exception
    {
        public InvalidAccountNumberException() : base("Неверный номер счета") { }

        public InvalidAccountNumberException(string message) : base(message) { }

        public InvalidAccountNumberException(string message, Exception inner) : base(message, inner) { }
    }

    class BankAccount
    {
        public string AccountNumber { get; private set; }

        public void ValidateAccount(string accountNumber)
        {
            if (!Regex.IsMatch(accountNumber, @"^\d{10}$"))
            {
                throw new InvalidAccountNumberException(
                    $"Номер счета '{accountNumber}' должен содержать ровно 10 цифр"
                );
            }

            AccountNumber = accountNumber;
            Console.WriteLine("Счет " + accountNumber + " валиден");
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount();

            string[] testNumbers = { "1234567890", "12345", "zxc1234567", "12345678901" };

            foreach (string num in testNumbers)
            {
                try
                {
                    account.ValidateAccount(num);
                }
                catch (InvalidAccountNumberException ex)
                {
                    Console.WriteLine("ОШИБКА: " + ex.Message);
                    Console.WriteLine("Тип: " + ex.GetType().Name);
                }
                finally
                {
                    Console.WriteLine("-");
                }
            }
        }
    }
}