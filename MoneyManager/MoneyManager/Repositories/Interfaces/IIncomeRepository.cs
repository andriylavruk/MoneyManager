using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<Income> GetByIdAsync(int? id);
        Task<IEnumerable<Income>> GetAllAsync();
        Task<IEnumerable<Income>> FindAsync(Expression<Func<Income, bool>> predicate);

        Task AddAsync(Income entity);
        Task RemoveAsync(Income entity);
        Task UpdateAsync(Income entity);

        Task<IEnumerable<Income>> SearchAsync(string searchString);
    }
}
