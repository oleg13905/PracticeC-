using System;

namespace Task1
{
    public interface IBankCard
    {
        string CardType { get; }
        void Use();
    }

    public class CreditCard : IBankCard
    {
        public string CardType => "Кредитная карта";

        public void Use()
        {
            Console.WriteLine("Кредитная карта: Использован кредитный лимит");
        }
    }

    public class DebitCard : IBankCard
    {
        public string CardType => "Дебетовая карта";

        public void Use()
        {
            Console.WriteLine("Дебетовая карта: Списаны средства со счета");
        }
    }

    public class VirtualCard : IBankCard
    {
        public string CardType => "Виртуальная карта";

        public void Use()
        {
            Console.WriteLine("Виртуальная карта: Оплата онлайн");
        }
    }

    public abstract class BankCardFactory
    {
        public abstract IBankCard CreateCard();
    }

    public class CreditCardFactory : BankCardFactory
    {
        public override IBankCard CreateCard()
        {
            return new CreditCard();
        }
    }

    public class DebitCardFactory : BankCardFactory
    {
        public override IBankCard CreateCard()
        {
            return new DebitCard();
        }
    }

    public class VirtualCardFactory : BankCardFactory
    {
        public override IBankCard CreateCard()
        {
            return new VirtualCard();
        }
    }

    class Program
    {
        static void Main()
        {
            BankCardFactory[] factories = {
            new CreditCardFactory(),
            new DebitCardFactory(),
            new VirtualCardFactory()
        };

            Console.WriteLine("Создание карт через фабричный метод:\n");

            foreach (BankCardFactory factory in factories)
            {
                IBankCard card = factory.CreateCard();
                Console.WriteLine($"Создана: {card.CardType}");
                card.Use();
                Console.WriteLine();
            }

            Console.WriteLine("Легко добавить новую карту\n");

            BankCardFactory creditFactory = new CreditCardFactory();
            IBankCard creditCard = creditFactory.CreateCard();
            creditCard.Use();
        }
    }
}