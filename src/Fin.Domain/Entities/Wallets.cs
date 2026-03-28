namespace Fin.Domain.Entities;

public class Wallet
{
    public int Id { get; set; }
    public decimal Limit { get; set; }
    IEnumerable<Transaction>? Transactions { get; set; } = new List<Transaction>();
}