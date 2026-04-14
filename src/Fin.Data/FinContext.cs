using Fin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fin.Data;

public class FinContext : DbContext
{
    public FinContext(DbContextOptions<FinContext> options) : base(options)
    {
    }

    public DbSet<Transaction>? Transactions { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Wallet>? Wallets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}