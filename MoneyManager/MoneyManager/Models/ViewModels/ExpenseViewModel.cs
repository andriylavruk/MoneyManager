using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MoneyManager.Models.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreated { get; set; }
        public int ExpenseTypeId { get; set; }
        public ExpenseTypeViewModel ExpenseType { get; set; }

        public decimal TotalExpense { get; set; }
        public decimal CurrentMonthExpense { get; set; }

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