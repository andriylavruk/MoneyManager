using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models.ViewModels
{
    public class StatisticsItemsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Опис")]
        public string Description { get; set; }

        [DisplayName("Сума")]
        public decimal Amount { get; set; }

        [DisplayName("Дата")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Категорія")]
        public string Catecategory { get; set; }

        public StatisticsItemsViewModel() { }

        public StatisticsItemsViewModel(StatisticsItemsViewModel statisticsViewModel)
        {
            Id = statisticsViewModel.Id;
            Description = statisticsViewModel.Description;
            Amount = statisticsViewModel.Amount;
            DateCreated = statisticsViewModel.DateCreated;
            Catecategory = statisticsViewModel.Catecategory;
        }

        public StatisticsItemsViewModel(Expense expense)
        {
            Id = expense.Id;
            Description = expense.Description;
            Amount = expense.Amount;
            DateCreated = expense.DateCreated;
            Catecategory = expense.ExpenseType.Name;
        }

        public StatisticsItemsViewModel(ExpenseViewModel expenseViewModel)
        {
            Id = expenseViewModel.Id;
            Description = expenseViewModel.Description;
            Amount = expenseViewModel.Amount;
            DateCreated = expenseViewModel.DateCreated;
            Catecategory = expenseViewModel.ExpenseType.Name;
        }
    }
}
