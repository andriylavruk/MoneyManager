using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyManager.Models.ViewModels
{
    public class ExpenseViewModel
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

        [DisplayName("Категорія витрат Id")]
        public int ExpenseTypeId { get; set; }

        public ExpenseTypeViewModel ExpenseType { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }

        public ExpenseViewModel() { }

        public ExpenseViewModel(Expense expense)
        {
            Id = expense.Id;
            Description = expense.Description;
            Amount = expense.Amount;
            DateCreated = expense.DateCreated;
            ExpenseTypeId = expense.ExpenseTypeId;
            ExpenseType = new ExpenseTypeViewModel(expense.ExpenseType);
        }

        public ExpenseViewModel(ExpenseViewModel expenseViewModel)
        {
            Id = expenseViewModel.Id;
            Description = expenseViewModel.Description;
            Amount = expenseViewModel.Amount;
            DateCreated = expenseViewModel.DateCreated;
            ExpenseTypeId = expenseViewModel.ExpenseTypeId;
            ExpenseType = expenseViewModel.ExpenseType;
        }
    }
}