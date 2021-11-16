using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Repositories.Services.Interfaces
{
    public interface IExpenseTypeService
    {
        Task<ExpenseTypeViewModel> GetExpenseTypeViewModelByIdAsync(int? id);
        Task<IEnumerable<ExpenseType>> GetAllExpenseTypesAsync();
        Task<IEnumerable<ExpenseType>> FindExpenseTypeAsync(Expression<Func<ExpenseType, bool>> predicate);

        Task AddExpenseTypeViewModelAsync(ExpenseTypeViewModel entity);
        Task RemoveExpenseTypeViewModelAsync(ExpenseTypeViewModel entity);
        Task UpdateExpenseTypeViewModelAsync(ExpenseTypeViewModel entity);

        Task<IEnumerable<SelectListItem>> GetExpenseTypesSelectListItemAsync();
    }
}