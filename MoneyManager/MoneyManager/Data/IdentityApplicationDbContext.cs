using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
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
}