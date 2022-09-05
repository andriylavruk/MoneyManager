using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models.ViewModels.IncomeTypeViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels.IncomeViewModels;

public class IncomeViewModel
{
    public int Id { get; set; }

    [DisplayName("Опис")]
    [MaxLength(50, ErrorMessage = "Максимальна кількість символів 50")]
    public string Description { get; set; }

    [DisplayName("Сума")]
    [Required(ErrorMessage = "Обов'язкове поле")]
    [Range(0, int.MaxValue, ErrorMessage = "Сума повинна бути більше 0.")]
    public int Amount { get; set; }

    [DisplayName("Дата")]
    public DateTime DateCreated { get; set; }

    [DisplayName("Категорія доходу Id")]
    public int IncomeTypeId { get; set; }

    public IncomeTypeViewModel? IncomeType { get; set; }

    public IEnumerable<SelectListItem>? TypeDropDown { get; set; }
}
