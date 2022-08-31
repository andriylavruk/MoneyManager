using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using MoneyManager.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MoneyManager.Repositories;

public class IncomeTypeRepository : IIncomeTypeRepository
{
    protected readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;


    public IncomeTypeRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IncomeType> GetByIdAsync(int? id)
    {
        return await _dbContext.IncomeTypes.
            Where(x => x.Id == id).
            FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<IncomeType>> GetAllAsync()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return await _dbContext.IncomeTypes.
            Where(x => x.UserId == userId).
            ToListAsync();
    }

    public async Task<IEnumerable<IncomeType>> FindAsync(Expression<Func<IncomeType, bool>> predicate)
    {
        return await _dbContext.Set<IncomeType>().Where(predicate).ToListAsync();
    }

    public async Task AddAsync(IncomeType entity)
    {
        entity.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _dbContext.IncomeTypes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(IncomeType entity)
    {
        if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(IncomeType entity)
    {
        if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<IncomeType>> SearchAsync(string searchString)
    {
        var incomeTypes = await GetAllAsync();

        return incomeTypes.Where(s => (s.Name.Contains(searchString)));
    }

    public async Task<IEnumerable<SelectListItem>> GetIncomeTypesSelectListItemAsync()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return await _dbContext.IncomeTypes.
            Where(x => x.UserId == userId).
            Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }).ToListAsync();
    }
}