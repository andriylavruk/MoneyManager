using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models.ViewModels;
using MoneyManager.Services.Interfaces;
using System.Threading.Tasks;

namespace MoneyManager.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var statistics = new StatisticsViewModel
            {
                TotalExpense = await _statisticsService.GetTotalExpenseAsync(),
                CurrentYearExpense = await _statisticsService.GetCurrentYearExpenseAsync(),
                CurrentMonthExpense = await _statisticsService.GetCurrentMonthExpenseAsync(),
                CurrentWeekExpense = await _statisticsService.GetCurrentWeekExpenseAsync(),
                ExpenseByExpenseType = await _statisticsService.GetTop5ExpenseByExpenseType(),

                TotalIncome = await _statisticsService.GetTotalIncomeAsync(),
                CurrentYearIncome = await _statisticsService.GetCurrentYearIncomeAsync(),
                CurrentMonthIncome = await _statisticsService.GetCurrentMonthIncomeAsync(),
                CurrentWeekIncome = await _statisticsService.GetCurrentWeekIncomeAsync(),
                IncomeByIncomeType = await _statisticsService.GetTop5IncomeByIncomeType()
            };

            return View(statistics);
        }
    }
}
