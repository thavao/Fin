namespace Fin.Domain.Entities;

public class Wallet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Limit { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    IEnumerable<Transaction>? Transactions { get; set; } = new List<Transaction>();
}