using Fin.Domain.Entities;

namespace Fin.Domain.Interfaces
{
    public interface IWalletRepository
    {
        Task CreateWalletAsync(Wallet wallet);
    }
}