using TodoListApp.Models;

namespace TodoListApp.Services;

public class TodoStore : ITodoStore
{
    private readonly List<TodoItem> _items = new();
    private readonly object _lock = new();
    private int _nextId = 1;

    public IReadOnlyList<TodoItem> GetAll()
    {
        lock (_lock)
        {
            return _items.OrderByDescending(t => t.Id).ToList();
        }
    }

    public void Add(string title)
    {
        var trimmed = title?.Trim() ?? string.Empty;
        if (trimmed.Length == 0)
            return;

        lock (_lock)
        {
            _items.Add(new TodoItem
            {
                Id = _nextId++,
                Title = trimmed,
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
