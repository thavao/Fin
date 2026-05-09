using Fin.Data;
using Fin.Domain.Entities;
using Fin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fin.Repository
{
    public class WalletRepository(FinContext dbContext) : IWalletRepository
    {
        private readonly FinContext _dbContext = dbContext;

        public Task CreateWalletAsync(Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
