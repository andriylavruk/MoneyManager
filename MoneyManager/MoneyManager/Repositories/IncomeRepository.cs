using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Data;
using MoneyManager.Models;
using MoneyManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoneyManager.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IncomeRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Income> GetByIdAsync(int? id)
        {
            return await _dbContext.Incomes.
                Include(x => x.IncomeType).
                Where(x => x.Id == id).
                FirstOrDefaultAsync();
        }

        public  async Task<IEnumerable<Income>> GetAllAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await _dbContext.Incomes.
                Include(x => x.IncomeType).
                Where(x => x.UserId == userId).
                ToListAsync();
        }

        public async Task<IEnumerable<Income>> FindAsync(Expression<Func<Income, bool>> predicate)
        {
            return await _dbContext.Set<Income>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Income entity)
        {
            entity.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _dbContext.Incomes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Income entity)
        {
            if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Income entity)
        {
            if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Income>> SearchAsync(string searchString)
        {
            var expenses = await GetAllAsync();

            return expenses.Where(s => !String.IsNullOrEmpty(s.Description)
                          && (s.IncomeType.Name.ToString().Contains(searchString)
                           || s.Description.Contains(searchString)
                           || s.DateCreated.ToShortDateString().Contains(searchString)
                           || s.Amount.ToString().Contains(searchString)));
        }
    }
}
