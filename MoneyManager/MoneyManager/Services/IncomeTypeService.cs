using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManager.Models;
using MoneyManager.Models.ViewModels.IncomeTypeViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Services.Interfaces;
using System.Linq.Expressions;

namespace MoneyManager.Services;

public class IncomeTypeService : IIncomeTypeService
{
    protected readonly IIncomeTypeRepository _repository;
    private readonly IMapper _mapper;

    public IncomeTypeService(IIncomeTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IncomeTypeViewModel> GetIncomeTypeViewModelByIdAsync(int? id)
    {
        var incomeType = await _repository.GetByIdAsync(id);
        var mappedIncomeType = _mapper.Map<IncomeTypeViewModel>(incomeType);

        return mappedIncomeType;
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
            var mappedIncomeType = _mapper.Map<IncomeType>(entity);

            await _repository.AddAsync(mappedIncomeType);
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