using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Repositories.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Services
{
    public class ExpenseService : IExpenseService
    {
        protected readonly IExpenseRepository _expenseRepository;
        protected readonly IExpenseTypeRepository _expenseTypeRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository)
        {
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
        }

        async Task<ExpenseViewModel> IExpenseService.GetExpenseViewModelByIdAsync(int? id)
        {
            return new ExpenseViewModel(await _expenseRepository.GetByIdAsync(id));
        }

        async Task<IEnumerable<Expense>> IExpenseService.GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllAsync();
        }

        async Task<IEnumerable<Expense>> IExpenseService.FindExpenseAsync(Expression<Func<Expense, bool>> predicate)
        {
            return await _expenseRepository.FindAsync(predicate);
        }

        async Task IExpenseService.AddExpenseViewModelAsync(ExpenseViewModel entity)
        {
            if (entity != null)
            {
                var expense = new Expense
                {
                    Id = entity.Id,
                    Description = entity.Description,
                    Amount = entity.Amount,
                    DateCreated = entity.DateCreated,
                    ExpenseTypeId = entity.ExpenseTypeId
                };

                await _expenseRepository.AddAsync(expense);
            }
        }

        async Task IExpenseService.RemoveExpenseViewModelAsync(ExpenseViewModel entity)
        {
            if (entity != null)
            {
                await _expenseRepository.RemoveAsync(await _expenseRepository.GetByIdAsync(entity.Id));
            }
        }

        async Task IExpenseService.UpdateExpenseViewModelAsync(ExpenseViewModel entity)
        {
            if (entity != null)
            {
                var expense = await _expenseRepository.GetByIdAsync(entity.Id);

                expense.Description = entity.Description;
                expense.ExpenseTypeId = entity.ExpenseTypeId;
                expense.Amount = entity.Amount;

                await _expenseRepository.UpdateAsync(expense);
            }
        }
    }
}