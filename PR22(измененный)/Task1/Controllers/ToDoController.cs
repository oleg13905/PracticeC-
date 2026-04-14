using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;

namespace Task1.Controllers;

public class ToDoController : Controller
{
    private readonly AppDbContext _db;

    public ToDoController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var items = await _db.ToDoItems
            .OrderBy(x => x.IsCompleted)
            .ThenBy(x => x.Deadline)
            .ThenBy(x => x.Id)
            .ToListAsync();

        return View(items);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ToDoItem { Deadline = DateOnly.FromDateTime(DateTime.Today) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Deadline")] ToDoItem model)
    {
        if (!ModelState.IsValid)
            return View(model);

        model.IsCompleted = false;
        _db.ToDoItems.Add(model);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        var item = await _db.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        if (item is null)
            return RedirectToAction(nameof(Index));

        item.IsCompleted = !item.IsCompleted;
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _db.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        if (item is null)
            return RedirectToAction(nameof(Index));

        _db.ToDoItems.Remove(item);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}

