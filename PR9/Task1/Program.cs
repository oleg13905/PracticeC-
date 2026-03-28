using System;
using System.Collections.Generic;

namespace Task1
{
    class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }

        public Task(int id, string title, int priority)
        {
            Id = id;
            Title = title;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"Task {Id}: {Title} (приоритет {Priority})";
        }
    }

    class TaskManager
    {
        private Queue<Task> tasks = new Queue<Task>();

        public void AddTask(Task task)
        {
            tasks.Enqueue(task);
            Console.WriteLine($"Добавлена: {task}");
        }

        public Task ProcessTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Очередь пуста!");
                return null;
            }

            Task task = tasks.Dequeue();
            Console.WriteLine($"Обработана: {task}");
            return task;
        }

        public void GetPendingTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет задач в очереди");
                return;
            }

            Console.WriteLine("\nОжидающие задачи:");
            foreach (Task t in tasks)
            {
                Console.WriteLine($"  {t}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TaskManager manager = new TaskManager();

            manager.AddTask(new Task(1, "Написать отчет", 3));
            manager.AddTask(new Task(2, "Проверить почту", 1));
            manager.AddTask(new Task(3, "Встреча с клиентом", 5));

            manager.GetPendingTasks();

            manager.ProcessTask();
            manager.ProcessTask();

            manager.GetPendingTasks();
        }
    }
}