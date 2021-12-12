using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Services.Interfaces
{
    public interface IIncomeTypeService
    {
        Task<IncomeTypeViewModel> GetIncomeTypeViewModelByIdAsync(int? id);
        Task<IEnumerable<IncomeType>> GetAllIncomeTypesAsync();
        Task<IEnumerable<IncomeType>> FindIncomeTypeAsync(Expression<Func<IncomeType, bool>> predicate);

        Task AddIncomeTypeViewModelAsync(IncomeTypeViewModel entity);
        Task RemoveIncomeTypeViewModelAsync(IncomeTypeViewModel entity);
        Task UpdateIncomeTypeViewModelAsync(IncomeTypeViewModel entity);

        Task<IEnumerable<IncomeType>> SearchIncomeTypeAsync(string searchString);

        Task<IEnumerable<SelectListItem>> GetIncomeTypesSelectListItemAsync();
    }
}
