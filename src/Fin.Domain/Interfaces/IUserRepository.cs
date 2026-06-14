using Fin.Domain.DTO.GetUserById;
using Fin.Domain.Entities;

namespace Fin.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<GetUserByIdRepositoryResponse?> GetUserByIdAsync(int id);
    }
}