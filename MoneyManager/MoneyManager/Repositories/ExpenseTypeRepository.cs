using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ExpenseTypeRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        async Task<ExpenseType> IExpenseTypeRepository.GetByIdAsync(int? id)
        {
            return await _dbContext.ExpenseTypes.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();
        }

        async Task<IEnumerable<ExpenseType>> IExpenseTypeRepository.GetAllAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await _dbContext.ExpenseTypes.
                Where(x => x.UserId == userId).
                ToListAsync();
        }

        async Task<IEnumerable<ExpenseType>> IExpenseTypeRepository.FindAsync(Expression<Func<ExpenseType, bool>> predicate)
        {
            return await _dbContext.Set<ExpenseType>().Where(predicate).ToListAsync();
        }

        async Task IExpenseTypeRepository.AddAsync(ExpenseType entity)
        {
            entity.UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            await _dbContext.ExpenseTypes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        async Task IExpenseTypeRepository.RemoveAsync(ExpenseType entity)
        {
            if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        async Task IExpenseTypeRepository.UpdateAsync(ExpenseType entity)
        {
            if (entity.UserId == _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<SelectListItem>> IExpenseTypeRepository.GetExpenseTypesSelectListItemAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return await _dbContext.ExpenseTypes.
                Where(x => x.UserId == userId).
                Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToListAsync();
        }
    }
}