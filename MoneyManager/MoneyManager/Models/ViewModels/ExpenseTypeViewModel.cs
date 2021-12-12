using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models.ViewModels
{
    public class ExpenseTypeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Категорія")]
        [Required(ErrorMessage = "Обов'язкове поле")]
        [MinLength(1, ErrorMessage = "Мінімальна кількість символів 1")]
        [MaxLength(20, ErrorMessage = "Максимальна кількість символів 20")]
        public string Name { get; set; }

        public ExpenseTypeViewModel() { }

        public ExpenseTypeViewModel(ExpenseType expenseType) 
        {
            Id = expenseType.Id;
            Name = expenseType.Name;
        }

        public ExpenseTypeViewModel(ExpenseTypeViewModel expenseTypeViewModel)
        {
            Id = expenseTypeViewModel.Id;
            Name = expenseTypeViewModel.Name;
        }
    }
}
