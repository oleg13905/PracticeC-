using System;
using System.Collections.Generic;

namespace Task3
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        int Count { get; }
    }

    public class SimpleQueue<T> : IQueue<T>
    {
        private Queue<T> queue = new Queue<T>();

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        public T Dequeue()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("Очередь пуста");
            return queue.Dequeue();
        }

        public T Peek()
        {
            if (queue.Count == 0)
                throw new InvalidOperationException("Очередь пуста");
            return queue.Peek();
        }

        public int Count => queue.Count;
    }

    public class QueueManager<T>
    {
        private IQueue<T> queue;

        public QueueManager(IQueue<T> queue)
        {
            this.queue = queue;
        }

        public void PrintQueue()
        {
            Console.Write("Очередь: ");

            int originalCount = queue.Count;
            SimpleQueue<T> temp = new SimpleQueue<T>();

            for (int i = 0; i < originalCount; i++)
            {
                T item = queue.Dequeue();
                Console.Write(item + " ");
                temp.Enqueue(item);
            }

            for (int i = 0; i < originalCount; i++)
            {
                queue.Enqueue(temp.Dequeue());
            }
            Console.WriteLine();
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        public void Add(T item)
        {
            queue.Enqueue(item);
            Console.WriteLine($"Добавлен: {item}");
        }

        public T Process()
        {
            T item = queue.Dequeue();
            Console.WriteLine($"Обработан: {item}");
            return item;
        }
    }

    class Program
    {
        static void Main()
        {
            IQueue<string> queue = new SimpleQueue<string>();
            QueueManager<string> manager = new QueueManager<string>(queue);

            manager.Add("задача1");
            manager.Add("задача2");
            manager.Add("задача3");

            manager.PrintQueue();
            Console.WriteLine($"Пустая: {manager.IsEmpty()}");

            Console.WriteLine("Peek: " + queue.Peek());
            manager.Process();
            manager.PrintQueue();
        }
    }
}