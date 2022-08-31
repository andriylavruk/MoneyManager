using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using MoneyManager.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MoneyManager.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    protected readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ExpenseRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Expense> GetByIdAsync(int? id)
    {
        return await _dbContext.Expenses.
            Include(x => x.ExpenseType).
            Where(x => x.Id == id).
            FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return await _dbContext.Expenses.
            Include(x => x.ExpenseType).
            Where(x => x.UserId == userId).
            ToListAsync();
    }

    public async Task<IEnumerable<Expense>> FindAsync(Expression<Func<Expense, bool>> predicate)
    {
        return await _dbContext.Set<Expense>().Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Expense entity)
    {
        entity.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _dbContext.Expenses.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Expense entity)
    {
        if(entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Expense entity)
    {
        if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Expense>> SearchAsync(string searchString)
    {
        var expenses = await GetAllAsync();

        return expenses.Where(s => !String.IsNullOrEmpty(s.Description)
                      && (s.ExpenseType.Name.ToString().Contains(searchString)
                       || s.Description.Contains(searchString)
                       || s.DateCreated.ToShortDateString().Contains(searchString)
                       || s.Amount.ToString().Contains(searchString)));
    }
}