namespace Fin.Domain.Entities;

public class User
{
    public User()
    {
        
    }
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public ICollection<Wallet>? Wallets { get; set; } = new List<Wallet>();

}