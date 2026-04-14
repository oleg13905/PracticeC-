using Task1.Models;

namespace Task1.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskViewModel> _items = new();
    private readonly object _lock = new();
    private int _nextId = 1;

    public IReadOnlyList<TaskViewModel> GetAll()
    {
        lock (_lock)
        {
            return _items
                .OrderByDescending(t => t.Id)
                .ToList();
        }
    }

    public void Add(TaskViewModel task)
    {
        if (task is null)
            return;

        var description = (task.Description ?? string.Empty).Trim();
        if (description.Length == 0)
            return;

        lock (_lock)
        {
            _items.Add(new TaskViewModel
            {
                Id = _nextId++,
                Description = description,
                DueDate = task.DueDate,
                IsCompleted = false
            });
        }
    }

    public bool Complete(int id)
    {
        lock (_lock)
        {
            var item = _items.FirstOrDefault(t => t.Id == id);
            if (item is null)
                return false;

            item.IsCompleted = true;
            return true;
        }
    }
}

