using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp.Controllers;

public class TodoController : Controller
{
    private readonly ITodoStore _store;

    public TodoController(ITodoStore store)
    {
        _store = store;
    }
    [HttpGet]
    public IActionResult Index(string? filter = "All")
    {
        var f = (filter ?? "All").Trim();
        if (string.IsNullOrEmpty(f))
            f = "All";

        var all = _store.GetAll();
        IEnumerable<TodoItem> query = all;

        if (f.Equals("Active", StringComparison.OrdinalIgnoreCase))
            query = all.Where(t => !t.IsCompleted);
        else if (f.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            query = all.Where(t => t.IsCompleted);

        var vm = new TodoIndexViewModel
        {
            Items = query.ToList(),
            Filter = f
        };

        return View(vm);
    }

    [HttpGet]
    public IActionResult Complete(int id)
    {
        _store.Complete(id);
        var filter = Request.Query["filter"].FirstOrDefault() ?? "All";
        return RedirectToAction(nameof(Index), new { filter });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(string title, string? filter = "All")
    {
        _store.Add(title);
        return RedirectToAction(nameof(Index), new { filter });
    }
}
