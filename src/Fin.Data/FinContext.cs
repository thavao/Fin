using Fin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fin.Data;

public class FinContext : DbContext
{
    public FinContext(DbContextOptions<FinContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<User> Users => Set<User>();
    public DbSet<FinancialBook> FinancialBooks => Set<FinancialBook>();
    public DbSet<Installment> Installments => Set<Installment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(200);
        });

        modelBuilder.Entity<FinancialBook>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            entity.Property(e => e.Limit)
                .HasPrecision(19, 4)
                .IsRequired();

            entity.Property(e => e.ClosingDay)
                .HasColumnType("tinyint")
                .IsRequired();

            entity.HasOne(f => f.User)
                .WithMany(u => u.FinancialBooks)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("uniqueidentifier");

            entity.Property(e => e.Name)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            entity.Property(e => e.DateReference)
                .IsRequired();

            entity.Property(e => e.Amount)
                .HasPrecision(19, 4)
                .IsRequired();

            entity.Property(e => e.InstallmentCount)
                .HasColumnType("tinyint");

            entity.Property(e => e.IsRecurring)
                .IsRequired();

            entity.Property(e => e.IsCredit)
                .IsRequired();

            entity.Property(e => e.IsPaid)
                .IsRequired();

            entity.Property(e => e.ExpirationDate)
                .IsRequired();

            entity.HasOne(t => t.FinancialBook)
                .WithMany(f => f.Transactions)
                .HasForeignKey(t => t.FinancialBookId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Installment>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.InstallmentNumber });

            entity.Property(e => e.TransactionId)
                .HasColumnType("uniqueidentifier");

            entity.Property(e => e.InstallmentNumber)
                .HasColumnType("tinyint");

            entity.Property(e => e.Value)
                .HasPrecision(19, 4)
                .IsRequired();

            entity.Property(e => e.DateReference)
                .IsRequired();

            entity.HasOne(e => e.Transaction)
                .WithMany(t => t.Installments)
                .HasForeignKey(e => e.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
