using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels;

public class IncomeTypeViewModel
{
    public int Id { get; set; }

    [DisplayName("Категорія")]
    [Required(ErrorMessage = "Обов'язкове поле")]
    [MinLength(1, ErrorMessage = "Мінімальна кількість символів 1")]
    [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
    public string Name { get; set; }

    public IncomeTypeViewModel() { }

    public IncomeTypeViewModel(IncomeType incomeType)
    {
        Id = incomeType.Id;
        Name = incomeType.Name;
    }

    public IncomeTypeViewModel(IncomeTypeViewModel incomeTypeViewModel)
    {
        Id = incomeTypeViewModel.Id;
        Name = incomeTypeViewModel.Name;
    }
}
