using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels.ExpenseTypeViewModels;

public class ExpenseTypeViewModel
{
    public int Id { get; set; }

    [DisplayName("Категорія")]
    [Required(ErrorMessage = "Обов'язкове поле")]
    [MinLength(1, ErrorMessage = "Мінімальна кількість символів 1")]
    [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
    public string Name { get; set; }
}
