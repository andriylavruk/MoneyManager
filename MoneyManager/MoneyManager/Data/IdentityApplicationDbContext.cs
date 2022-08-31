using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoneyManager.Data;

public class IdentityApplicationDbContext : IdentityDbContext
{
    private readonly DbContextOptions _options;

    public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options)
    {
        _options = options;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}