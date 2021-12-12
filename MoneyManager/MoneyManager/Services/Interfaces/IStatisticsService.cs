using MoneyManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetTotalExpenseAsync();
        Task<int> GetCurrentYearExpenseAsync();
        Task<int> GetCurrentMonthExpenseAsync();
        Task<int> GetCurrentWeekExpenseAsync();
        Task<IEnumerable<Tuple<string, int>>> GetTop5ExpenseByExpenseType();

        Task<int> GetTotalIncomeAsync();
        Task<int> GetCurrentYearIncomeAsync();
        Task<int> GetCurrentMonthIncomeAsync();
        Task<int> GetCurrentWeekIncomeAsync();
        Task<IEnumerable<Tuple<string, int>>> GetTop5IncomeByIncomeType();
    }
}