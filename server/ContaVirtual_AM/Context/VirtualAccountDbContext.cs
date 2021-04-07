using ContaVirtual_AM.Domain.v1.Accounts;
using Microsoft.EntityFrameworkCore;

namespace ContaVirtual_AM.Context
{
    public class VirtualAccountDbContext : DbContext
    {
        public VirtualAccountDbContext(DbContextOptions<VirtualAccountDbContext> options)
           : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountEntityTypeConfiguration().Configure(modelBuilder.Entity<Account>());
        }
    }
}