using TodoListApp.Models;

namespace TodoListApp.Services;

public interface ITodoStore
{
    IReadOnlyList<TodoItem> GetAll();
    void Add(string title);
    bool Complete(int id);
}
