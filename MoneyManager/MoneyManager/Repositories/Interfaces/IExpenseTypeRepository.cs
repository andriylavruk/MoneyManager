using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<ExpenseType> GetByIdAsync(int? id);
        Task<IEnumerable<ExpenseType>> GetAllAsync();
        Task<IEnumerable<ExpenseType>> FindAsync(Expression<Func<ExpenseType, bool>> predicate);

        Task AddAsync(ExpenseType entity);
        Task RemoveAsync(ExpenseType entity);
        Task UpdateAsync(ExpenseType entity);

        Task<IEnumerable<ExpenseType>> SearchAsync(string searchString);

        Task<IEnumerable<SelectListItem>> GetExpenseTypesSelectListItemAsync();
    }
}