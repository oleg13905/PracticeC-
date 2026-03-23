using System;

namespace Task4
{

    interface IEmailNotifier
    {
        void SendNotification(string message);
    }

    interface ISmsNotifier
    {
        void SendNotification(string message);
    }

    class NotificationService : IEmailNotifier, ISmsNotifier
    {
        void IEmailNotifier.SendNotification(string message)
        {
            Console.WriteLine("Email: " + message);
        }

        void ISmsNotifier.SendNotification(string message)
        {
            Console.WriteLine("SMS: " + message);
        }

        public void SendEmail(string msg)
        {
            ((IEmailNotifier)this).SendNotification(msg);
        }

        public void SendSms(string msg)
        {
            ((ISmsNotifier)this).SendNotification(msg);
        }
    }

    class Program
    {
        static void Main()
        {
            NotificationService service = new NotificationService();

            IEmailNotifier email = service;
            ISmsNotifier sms = service;

            email.SendNotification("Заказ подтвержден");
            sms.SendNotification("Ваш заказ готов");

            Console.WriteLine();

            service.SendEmail("Платеж получен");
            service.SendSms("Доставка завтра");
        }
    }
}