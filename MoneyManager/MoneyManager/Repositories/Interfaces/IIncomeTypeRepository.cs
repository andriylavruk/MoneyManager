using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Interfaces
{
    public interface IIncomeTypeRepository
    {
        Task<IncomeType> GetByIdAsync(int? id);
        Task<IEnumerable<IncomeType>> GetAllAsync();
        Task<IEnumerable<IncomeType>> FindAsync(Expression<Func<IncomeType, bool>> predicate);

        Task AddAsync(IncomeType entity);
        Task RemoveAsync(IncomeType entity);
        Task UpdateAsync(IncomeType entity);

        Task<IEnumerable<IncomeType>> SearchAsync(string searchString);

        Task<IEnumerable<SelectListItem>> GetIncomeTypesSelectListItemAsync();
    }
}
