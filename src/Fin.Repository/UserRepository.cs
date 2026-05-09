using Fin.Data;
using Fin.Domain.Entities;
using Fin.Domain.Interfaces;

namespace Fin.Repository;

public class UserRepository(FinContext dbContext) :IUserRepository
{
    private readonly FinContext _dbContext = dbContext;

    public Task CreateUserAsync(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}
