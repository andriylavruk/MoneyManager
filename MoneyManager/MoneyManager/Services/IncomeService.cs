using MoneyManager.Models;
using MoneyManager.Models.ViewModels;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Services.Interfaces;
using System.Linq.Expressions;

namespace MoneyManager.Services;

public class IncomeService : IIncomeService
{
    protected readonly IIncomeRepository _incomeRepository;
    protected readonly IIncomeTypeRepository _incomeTypeRepository;

    public IncomeService(IIncomeRepository incomeRepository, IIncomeTypeRepository incomeTypeRepository)
    {
        _incomeRepository = incomeRepository;
        _incomeTypeRepository = incomeTypeRepository;
    }

    public async Task<IncomeViewModel> GetIncomeViewModelByIdAsync(int? id)
    {
        return new IncomeViewModel(await _incomeRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<Income>> GetAllIncomesAsync()
    {
        return await _incomeRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Income>> FindIncomeAsync(Expression<Func<Income, bool>> predicate)
    {
        return await _incomeRepository.FindAsync(predicate);
    }

    public async Task AddIncomeViewModelAsync(IncomeViewModel entity)
    {
        if (entity != null)
        {
            var income = new Income
            {
                Id = entity.Id,
                Description = entity.Description,
                Amount = entity.Amount,
                DateCreated = entity.DateCreated,
                IncomeTypeId = entity.IncomeTypeId
            };

            await _incomeRepository.AddAsync(income);
        }
    }

    public async Task RemoveIncomeViewModelAsync(IncomeViewModel entity)
    {
        if (entity != null)
        {
            await _incomeRepository.RemoveAsync(await _incomeRepository.GetByIdAsync(entity.Id));
        }
    }

    public async Task UpdateIncomeViewModelAsync(IncomeViewModel entity)
    {
        if (entity != null)
        {
            var income = await _incomeRepository.GetByIdAsync(entity.Id);

            income.Description = entity.Description;
            income.IncomeTypeId = entity.IncomeTypeId;
            income.Amount = entity.Amount;

            await _incomeRepository.UpdateAsync(income);
        }
    }

    public async Task<IEnumerable<Income>> SearchIncomeAsync(string searchString)
    {
        return await _incomeRepository.SearchAsync(searchString);
    }
}