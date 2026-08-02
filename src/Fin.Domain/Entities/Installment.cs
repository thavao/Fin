namespace Fin.Domain.Entities;

public class Installment
{
    public Guid TransactionId { get; set; }
    public byte InstallmentNumber { get; set; }
    public decimal Value { get; set; }
    public DateTime DateReference { get; set; }
    public Transaction Transaction { get; set; } = null!;
}
