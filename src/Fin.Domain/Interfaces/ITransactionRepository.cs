using Fin.Domain.Entities;

namespace Fin.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task CreateTransactionAsync(Transaction transaction);
    }
}
