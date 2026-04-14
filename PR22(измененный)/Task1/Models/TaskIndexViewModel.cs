namespace Task1.Models;

public class TaskIndexViewModel
{
    public IReadOnlyList<TaskViewModel> Items { get; set; } = Array.Empty<TaskViewModel>();
    public TaskViewModel NewTask { get; set; } = new();
}

