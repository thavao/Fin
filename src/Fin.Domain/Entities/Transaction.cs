namespace Fin.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime DateReference { get; set; }
    public decimal Amount { get; set; }
    public byte? InstallmentCount { get; set; }
    public Guid FinancialBookId { get; set; }
    public bool IsRecurring { get; set; }
    public bool IsCredit { get; set; }
    public DateTime? DateToPay { get; set; }
    public bool IsPaid { get; set; }
    public DateTime ExpirationDate { get; set; }
    public FinancialBook FinancialBook { get; set; } = null!;
    public ICollection<Installment> Installments { get; set; } = [];
}
