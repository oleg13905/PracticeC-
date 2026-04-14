using System.ComponentModel.DataAnnotations;

namespace Task1.Models;

public class ToDoItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }

    [DataType(DataType.Date)]
    public DateOnly Deadline { get; set; }
}

