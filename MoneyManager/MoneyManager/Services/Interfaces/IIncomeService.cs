using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Services.Interfaces
{
    public interface IIncomeService
    {
        Task<IncomeViewModel> GetIncomeViewModelByIdAsync(int? id);
        Task<IEnumerable<Income>> GetAllIncomesAsync();
        Task<IEnumerable<Income>> FindIncomeAsync(Expression<Func<Income, bool>> predicate);

        Task AddIncomeViewModelAsync(IncomeViewModel entity);
        Task RemoveIncomeViewModelAsync(IncomeViewModel entity);
        Task UpdateIncomeViewModelAsync(IncomeViewModel entity);

        Task<IEnumerable<Income>> SearchIncomeAsync(string searchString);
    }
}