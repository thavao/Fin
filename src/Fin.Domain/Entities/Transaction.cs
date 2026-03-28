using Fin.Domain.Enums;

namespace Fin.Domain.Entities;

public class Transaction
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Amoount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int Installment { get; set; }
    public int InstallmentCount { get; set; }
    public required Wallet Wallet { get; set; } = new Wallet();
    public required bool IsRecurring { get; set; }
    public required TransactionType Type { get; set; }
    public required DateTime DueDate { get; set; }
    public required TransactionStatus Status { get; set; }
}