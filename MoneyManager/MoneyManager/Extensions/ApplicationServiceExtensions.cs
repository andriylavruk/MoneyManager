using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Repositories;
using MoneyManager.Repositories.Interfaces;
using MoneyManager.Repositories.Services;
using MoneyManager.Repositories.Services.Interfaces;
using MoneyManager.Services;
using MoneyManager.Services.Interfaces;

namespace MoneyManager.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<IExpenseTypeService, ExpenseTypeService>();

            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IExpenseService, ExpenseService>();

            services.AddScoped<IIncomeTypeRepository, IncomeTypeRepository>();
            services.AddScoped<IIncomeTypeService, IncomeTypeService>();

            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IIncomeService, IncomeService>();

            services.AddScoped<IStatisticsService, StatisticsService>();

            return services;
        }
    }
}