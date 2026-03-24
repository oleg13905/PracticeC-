using System;

namespace Task3
{

    public delegate void StatusChangedHandler(string orderId, string newStatus);

    class OrderStatusManager
    {
        public event StatusChangedHandler StatusChanged;

        public void ChangeStatus(string orderId, string status)
        {
            Console.WriteLine($"Статус заказа {orderId} изменен на: {status}");
            StatusChanged?.Invoke(orderId, status);
        }
    }

    class CustomerNotifier
    {
        public void OnStatusChanged(string orderId, string status)
        {
            Console.WriteLine($"Клиент: Заказ {orderId} теперь '{status}'");
        }
    }

    class AdminLogger
    {
        public void OnStatusChanged(string orderId, string status)
        {
            Console.WriteLine($"ЛОГ: {orderId} -> {status}");
        }
    }

    class Program
    {
        static void Main()
        {
            OrderStatusManager manager = new OrderStatusManager();

            CustomerNotifier customer = new CustomerNotifier();
            AdminLogger logger = new AdminLogger();

            manager.StatusChanged += customer.OnStatusChanged;
            manager.StatusChanged += logger.OnStatusChanged;

            manager.ChangeStatus("13045553", "Подтвержден");
            Console.WriteLine();
            manager.ChangeStatus("13045553", "Отправлен");
        }
    }
}