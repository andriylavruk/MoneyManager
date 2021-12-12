using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalExpense { get; set; }
        public int CurrentYearExpense { get; set; }
        public int CurrentMonthExpense { get; set; }
        public int CurrentWeekExpense { get; set; }
        public IEnumerable<Tuple<string, int>> ExpenseByExpenseType { get; set; }
    }
}
