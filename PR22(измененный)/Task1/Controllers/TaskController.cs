using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Services;

namespace Task1.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _tasks;

    public TaskController(ITaskService tasks)
    {
        _tasks = tasks;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.CompleteMessage = TempData["CompleteMessage"] as string;

        var vm = new TaskIndexViewModel
        {
            Items = _tasks.GetAll(),
            NewTask = new TaskViewModel
            {
                DueDate = DateOnly.FromDateTime(DateTime.Today)
            }
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(TaskIndexViewModel model)
    {
        ViewBag.CompleteMessage = TempData["CompleteMessage"] as string;

        model.Items = _tasks.GetAll();

        if (!ModelState.IsValid)
            return View("Index", model);

        _tasks.Add(model.NewTask);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Complete(int id)
    {
        var ok = _tasks.Complete(id);
        ViewBag.CompleteMessage = ok ? "Задача завершена." : "Задача не найдена.";
        TempData["CompleteMessage"] = (string)ViewBag.CompleteMessage;
        return RedirectToAction(nameof(Index));
    }
}

