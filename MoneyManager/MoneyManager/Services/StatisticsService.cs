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

        public StatisticsService(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
        }

        public async Task<List<StatisticsItemsViewModel>> GetAllStatisticsItemsAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();
            var allItems = new List<StatisticsItemsViewModel>();

            foreach (var item in allExpenses)
            {
                allItems.Add(new StatisticsItemsViewModel(item));
            }

            var result = allItems.OrderBy(x => x.DateCreated);

            return result.ToList();
        }

        public async Task<decimal> GetTotalExpenseAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses.Sum(x => x.Amount);
        }

        public async Task<decimal> GetCurrentMonthExpenseAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync();

            return allExpenses
                .Where(x => x.DateCreated.Month == DateTime.Now.Month)
                .Sum(x => x.Amount);
        }

        /*public async Task<Dictionary<string, decimal>> GetTotalExpenseByExpenseTypeAsync()
        {
            var expenseTypes = await _expenseTypeRepository.GetAllAsync();

            Dictionary<string, decimal> result = null;

            for (int i = 0; i < expenseTypes.Count(); i++)
            {
                result.Add(expenseTypes.ToString(), );
            }

            foreach(var i in expenseTypes)
            {
                result.Add(i, await _expenseRepository.FindAsync(x => x.ExpenseType.Name == i.Name));
            }
            //var result = expenseTypes.ToDictionary(k => k, v => );

            throw new NotImplementedException();
        }*/
    }
}
