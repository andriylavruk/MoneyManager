using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using System.Linq.Expressions;

namespace MoneyManager.Repositories.Services.Interfaces;

public interface IExpenseService
{
    Task<ExpenseViewModel> GetExpenseViewModelByIdAsync(int? id);
    Task<IEnumerable<Expense>> GetAllExpensesAsync();
    Task<IEnumerable<Expense>> FindExpenseAsync(Expression<Func<Expense, bool>> predicate);

    Task AddExpenseViewModelAsync(ExpenseViewModel entity);
    Task RemoveExpenseViewModelAsync(ExpenseViewModel entity);
    Task UpdateExpenseViewModelAsync(ExpenseViewModel entity);

    Task<IEnumerable<Expense>> SearchExpenseAsync(string searchString);
}