using MoneyManager.Models;
using System.Linq.Expressions;

namespace MoneyManager.Repositories.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(int? id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task<IEnumerable<Expense>> FindAsync(Expression<Func<Expense, bool>> predicate);

    Task AddAsync(Expense entity);
    Task RemoveAsync(Expense entity);
    Task UpdateAsync(Expense entity);

    Task<IEnumerable<Expense>> SearchAsync(string searchString);
}