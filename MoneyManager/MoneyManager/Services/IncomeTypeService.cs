using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MoneyManager.Services
{
    public class IncomeTypeService : IIncomeTypeService
    {
        protected readonly IIncomeTypeRepository _repository;

        public IncomeTypeService(IIncomeTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IncomeTypeViewModel> GetIncomeTypeViewModelByIdAsync(int? id)
        {
            return new IncomeTypeViewModel(await _repository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<IncomeType>> GetAllIncomeTypesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<IncomeType>> FindIncomeTypeAsync(Expression<Func<IncomeType, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public async Task AddIncomeTypeViewModelAsync(IncomeTypeViewModel entity)
        {
            if (entity != null)
            {
                var expenseType = new IncomeType
                {
                    Name = entity.Name
                };

                await _repository.AddAsync(expenseType);
            }
        }

        public async Task RemoveIncomeTypeViewModelAsync(IncomeTypeViewModel entity)
        {
            if (entity != null)
            {
                await _repository.RemoveAsync(await _repository.GetByIdAsync(entity.Id));
            }
        }

        public async Task UpdateIncomeTypeViewModelAsync(IncomeTypeViewModel entity)
        {
            if (entity != null)
            {
                var expenseType = await _repository.GetByIdAsync(entity.Id);

                expenseType.Name = entity.Name;

                await _repository.UpdateAsync(expenseType);
            }
        }

        public async Task<IEnumerable<IncomeType>> SearchIncomeTypeAsync(string searchString)
        {
            return await _repository.SearchAsync(searchString);
        }


        public async Task<IEnumerable<SelectListItem>> GetIncomeTypesSelectListItemAsync()
        {
            return await _repository.GetIncomeTypesSelectListItemAsync();
        }
    }
}