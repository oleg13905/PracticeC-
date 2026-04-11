namespace TodoListApp.Models;

public class TodoIndexViewModel
{
    public IReadOnlyList<TodoItem> Items { get; init; } = Array.Empty<TodoItem>();
    public string Filter { get; init; } = "All";
    public string? NewTitle { get; set; }
}
