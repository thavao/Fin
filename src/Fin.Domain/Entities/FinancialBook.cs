namespace Fin.Domain.Entities;

public class FinancialBook
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid UserId { get; set; }
    public decimal Limit { get; set; }
    public byte ClosingDay { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Transaction> Transactions { get; set; } = [];
}
