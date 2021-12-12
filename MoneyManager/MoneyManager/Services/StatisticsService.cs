using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IIncomeTypeRepository _incomeTypeRepository;

        public StatisticsService(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository, 
            IIncomeRepository incomeRepository, IIncomeTypeRepository incomeTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
            _incomeRepository = incomeRepository;
            _incomeTypeRepository = incomeTypeRepository;
        }

        public async Task<int> GetTotalExpenseAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses.Sum(x => x.Amount);
        }

        public async Task<int> GetCurrentYearExpenseAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses
                .Where(x => x.DateCreated.Year == DateTime.Now.Year)
                .Sum(x => x.Amount);
        }

        public async Task<int> GetCurrentMonthExpenseAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses
                .Where(x => x.DateCreated.Month == DateTime.Now.Month)
                .Sum(x => x.Amount);
        }

        public async Task<int> GetCurrentWeekExpenseAsync()
        {
            var currentStartDayOfWeek = DateTime.Today.AddDays(DayOfWeek.Monday - DateTime.Today.DayOfWeek);
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses
                .Where(x => x.DateCreated >= currentStartDayOfWeek 
                    && x.DateCreated <= currentStartDayOfWeek.AddDays(7))
                .Sum(x => x.Amount);
        }

        public async Task<IEnumerable<Tuple<string, int>>> GetExpenseByExpenseType()
        {
            var expenses = await _expenseRepository.GetAllAsync();

            var result = expenses
                     .Where(z => z.DateCreated.Month == DateTime.Now.Month)
                     .GroupBy(y => y.ExpenseType.Name)
                     .Select(x => new
                     {
                         Name = x.Key,
                         Sum = x.Sum(s => s.Amount)
                     });

            var tuples = new List<Tuple<string, int>>();

            foreach(var item in result)
            {
                tuples.Add(new Tuple<string, int>(item.Name, item.Sum));
            }

            return tuples;
        }
    }
}
