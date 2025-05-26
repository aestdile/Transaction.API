using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Transaction.API.DataAccess.Entities;

namespace Transaction.API.DataAcces;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
        : base(dbContextOptions) { }

    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<BankTransaction> Transactions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.Property(e => e.Balance).HasPrecision(18, 2);
        });

        modelBuilder.Entity<BankTransaction>(entity =>
        {
            entity.Property(e => e.Amount).HasPrecision(18, 2);
        });
    }
}

