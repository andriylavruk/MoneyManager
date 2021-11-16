using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models.ViewModels
{
    public class ExpenseTypeViewModel
    {
        public int Id { get; set; }
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
