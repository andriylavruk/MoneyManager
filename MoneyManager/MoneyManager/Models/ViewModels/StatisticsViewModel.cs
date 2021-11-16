using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public IEnumerable<StatisticsItemsViewModel> StatisticsItemsViewModelsCollection { get; set; }

        public decimal TotalExpense { get; set; }
        public decimal CurrentMonthExpense { get; set; }
    }
}
