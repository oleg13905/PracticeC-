using System.ComponentModel.DataAnnotations;

namespace Task1.Models;

public class TaskViewModel : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Описание обязательно.")]
    [StringLength(500, ErrorMessage = "Описание должно быть не длиннее 500 символов.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Срок выполнения обязателен.")]
    [DataType(DataType.Date)]
    public DateOnly DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        if (DueDate < today)
        {
            yield return new ValidationResult(
                "Дата не может быть в прошлом.",
                new[] { nameof(DueDate) });
        }
    }
}

