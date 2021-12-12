using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Models.ViewModels;
using MoneyManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
                ExpenseByExpenseType = await _statisticsService.GetExpenseByExpenseType()
            };

            return View(statistics);
        }
    }
}
