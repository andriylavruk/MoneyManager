using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models.ViewModels.ExpenseTypeViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models.ViewModels.ExpenseViewModels;

public class ExpenseViewModel
{
    /*    public int Id { get; set; }

        [DisplayName("Опис")]
        [MaxLength(50, ErrorMessage = "Максимальна кількість символів 50")]
        public string Description { get; set; }

        [DisplayName("Сума")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [Range(0, int.MaxValue, ErrorMessage = "Сума повинна бути більше 0.")]
        public int Amount { get; set; }

        [DisplayName("Дата")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Категорія витрат Id")]
        public int ExpenseTypeId { get; set; }

        public IEnumerable<SelectListItem>? TypeDropDown { get; set; }*/



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

    [DisplayName("Категорія витрат Id")]
    public int ExpenseTypeId { get; set; }

    public ExpenseTypeViewModel? ExpenseType { get; set; }

    public IEnumerable<SelectListItem>? TypeDropDown { get; set; }
}