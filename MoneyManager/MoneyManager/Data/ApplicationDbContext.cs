using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;

namespace MoneyManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseType> ExpenseTypes { get; set; }

    public DbSet<Income> Incomes { get; set; }
    public DbSet<IncomeType> IncomeTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.Property(x => x.DateCreated).HasDefaultValueSql("getdate()");
        });
    }
    
}