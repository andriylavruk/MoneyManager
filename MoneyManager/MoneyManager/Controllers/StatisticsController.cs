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
                StatisticsItemsViewModelsCollection = await _statisticsService.GetAllStatisticsItemsAsync(),
                TotalExpense = await _statisticsService.GetTotalExpenseAsync(),
                CurrentMonthExpense = await _statisticsService.GetCurrentMonthExpenseAsync()
            };

            return View(statistics);
        }
    }
}
