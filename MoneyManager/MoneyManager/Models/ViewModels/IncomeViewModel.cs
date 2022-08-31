using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels;

public class IncomeViewModel
{
    public int Id { get; set; }

    [DisplayName("Опис")]
    [MaxLength(50, ErrorMessage = "Максимальна кількість символів 50")]
    public string Description { get; set; }

    [DisplayName("Сума")]
    [Required(ErrorMessage = "Обов'язкове поле")]
    [Range(0, Int32.MaxValue, ErrorMessage = "Сума повинна бути більше 0.")]
    public int Amount { get; set; }

    [DisplayName("Дата")]
    public DateTime DateCreated { get; set; }

    [DisplayName("Категорія доходу Id")]
    public int IncomeTypeId { get; set; }

    public IncomeTypeViewModel? IncomeType { get; set; }

    public IEnumerable<SelectListItem>? TypeDropDown { get; set; }

    public IncomeViewModel() { }

    public IncomeViewModel(Income income)
    {
        Id = income.Id;
        Description = income.Description;
        Amount = income.Amount;
        DateCreated = income.DateCreated;
        IncomeTypeId = income.IncomeTypeId;
        IncomeType = new IncomeTypeViewModel(income.IncomeType);
    }

    public IncomeViewModel(IncomeViewModel incomeViewModel)
    {
        Id = incomeViewModel.Id;
        Description = incomeViewModel.Description;
        Amount = incomeViewModel.Amount;
        DateCreated = incomeViewModel.DateCreated;
        IncomeTypeId = incomeViewModel.IncomeTypeId;
        IncomeType = incomeViewModel.IncomeType;
    }
}
