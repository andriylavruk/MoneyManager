using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Repositories.Services.Interfaces;
using System.Linq.Expressions;

namespace MoneyManager.Repositories.Services;

public class ExpenseTypeService : IExpenseTypeService
{
    protected readonly IExpenseTypeRepository _repository;

    public ExpenseTypeService(IExpenseTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExpenseTypeViewModel> GetExpenseTypeViewModelByIdAsync(int? id)
    {
        return new ExpenseTypeViewModel(await _repository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<ExpenseType>> GetAllExpenseTypesAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<IEnumerable<ExpenseType>> FindExpenseTypeAsync(Expression<Func<ExpenseType, bool>> predicate)
    {
        return await _repository.FindAsync(predicate);
    }

    public async Task AddExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
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

    public async Task RemoveExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
    {
        if (entity != null)
        {
            await _repository.RemoveAsync(await _repository.GetByIdAsync(entity.Id));
        }
    }

    public async Task UpdateExpenseTypeViewModelAsync(ExpenseTypeViewModel entity)
    {
        if (entity != null)
        {
            var expenseType = await _repository.GetByIdAsync(entity.Id);

            expenseType.Name = entity.Name;

            await _repository.UpdateAsync(expenseType);
        }
    }

    public async Task<IEnumerable<ExpenseType>> SearchExpenseTypeAsync(string searchString)
    {
        return await _repository.SearchAsync(searchString);
    }

    public async Task<IEnumerable<SelectListItem>> GetExpenseTypesSelectListItemAsync()
    {
        return await _repository.GetExpenseTypesSelectListItemAsync();
    }
}