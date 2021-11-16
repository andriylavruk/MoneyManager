using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Repositories.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        protected readonly IExpenseTypeRepository _repository;

        public ExpenseTypeService(IExpenseTypeRepository repository)
        {
            _repository = repository;
        }

        async Task<ExpenseTypeViewModel> IExpenseTypeService.GetExpenseTypeViewModelByIdAsync(int? id)
        {
            return new ExpenseTypeViewModel(await _repository.GetByIdAsync(id));
        }

        async Task<IEnumerable<ExpenseType>> IExpenseTypeService.GetAllExpenseTypesAsync()
        {
            return await _repository.GetAllAsync();
        }

        async Task<IEnumerable<ExpenseType>> IExpenseTypeService.FindExpenseTypeAsync(Expression<Func<ExpenseType, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        async Task IExpenseTypeService.AddExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
        {
            if (entity != null)
            {
                var expenseType = new ExpenseType
                {
                    Name = entity.Name
                };

                await _repository.AddAsync(expenseType);
            }
        }

        async Task IExpenseTypeService.RemoveExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
        {
            if (entity != null)
            {
                await _repository.RemoveAsync(await _repository.GetByIdAsync(entity.Id));
            }
        }

        async Task IExpenseTypeService.UpdateExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
        {
            if (entity != null)
            {
                var expenseType = await _repository.GetByIdAsync(entity.Id);

                expenseType.Name = entity.Name;

                await _repository.UpdateAsync(expenseType);
            }
        }

        async Task<IEnumerable<SelectListItem>> IExpenseTypeService.GetExpenseTypesSelectListItemAsync()
        {
            return await _repository.GetExpenseTypesSelectListItemAsync();
        }
    }
}