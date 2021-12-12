using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Interfaces
{
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
}