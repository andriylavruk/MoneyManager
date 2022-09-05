using AutoMapper;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels.ExpenseTypeViewModels;
using MoneyManager.Models.ViewModels.ExpenseViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Services.Interfaces;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace MoneyManager.Services;

public class ExpenseService : IExpenseService
{
    protected readonly IExpenseRepository _expenseRepository;
    protected readonly IExpenseTypeRepository _expenseTypeRepository;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseRepository expenseRepository, IExpenseTypeRepository expenseTypeRepository, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _expenseTypeRepository = expenseTypeRepository;
        _mapper = mapper;
    }

    public async Task<ExpenseViewModel> GetExpenseViewModelByIdAsync(int? id)
    {
        var expense = await _expenseRepository.GetByIdAsync(id);
        var mappedExpense = _mapper.Map<ExpenseViewModel>(expense);

        return mappedExpense;
    }

    public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
    {
        return await _expenseRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Expense>> FindExpenseAsync(Expression<Func<Expense, bool>> predicate)
    {
        return await _expenseRepository.FindAsync(predicate);
    }

    public async Task AddExpenseViewModelAsync(ExpenseViewModel entity)
    {
        if (entity != null)
        {
            var expense = _mapper.Map<Expense>(entity);

            await _expenseRepository.AddAsync(expense);
        }
    }

    public async Task RemoveExpenseViewModelAsync(ExpenseViewModel entity)
    {
        if (entity != null)
        {
            await _expenseRepository.RemoveAsync(await _expenseRepository.GetByIdAsync(entity.Id));
        }
    }

    public async Task UpdateExpenseViewModelAsync(ExpenseViewModel entity)
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

    public async Task<IEnumerable<Expense>> SearchExpenseAsync(string searchString)
    {
        return await _expenseRepository.SearchAsync(searchString);
    }
}