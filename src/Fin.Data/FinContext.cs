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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(p => p.Limit)
                .HasColumnType("decimal(7,2)");

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(w => w.User)
                .WithMany(u => u.Wallets)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .HasMaxLength(500);

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.TransactionDate)
                .IsRequired();

            entity.Property(e => e.Installment)
                .IsRequired();

            entity.Property(e => e.InstallmentCount)
                .IsRequired();

            entity.Property(e => e.IsRecurring)
                .IsRequired();

            entity.Property(e => e.Type)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(e => e.DueDate)
                .IsRequired();

            entity.Property(e => e.Status)
                .HasConversion<int>()
                .IsRequired();

            entity.HasOne(t => t.Wallet)
                .WithMany()
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}