using MoneyManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<List<StatisticsItemsViewModel>> GetAllStatisticsItemsAsync();

        Task<decimal> GetTotalExpenseAsync();
        Task<decimal> GetCurrentMonthExpenseAsync();
        //Task<Dictionary<string, decimal>> GetTotalExpenseByExpenseTypeAsync();
    }
}
