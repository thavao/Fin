using Fin.Data;
using Fin.Domain.DTO.GetUserById;
using Fin.Domain.Entities;
using Fin.Domain.Interfaces;

namespace Fin.Repository;

public class UserRepository(FinContext dbContext) : IUserRepository
{
    private readonly FinContext _dbContext = dbContext;

    public async Task CreateUserAsync(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public async Task<GetUserByIdRepositoryResponse?> GetUserByIdAsync(int id)
    {
        var user = await _dbContext.FindAsync<User>(id);
        if (user is null)
        {
            return null;
        }
        return new GetUserByIdRepositoryResponse
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };
    }
}
