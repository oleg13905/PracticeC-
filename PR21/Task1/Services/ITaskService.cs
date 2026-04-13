using Task1.Models;

namespace Task1.Services;

public interface ITaskService
{
    IReadOnlyList<TaskViewModel> GetAll();
    void Add(TaskViewModel task);
    bool Complete(int id);
}

