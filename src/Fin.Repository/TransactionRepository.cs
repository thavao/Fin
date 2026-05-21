using Fin.Data;
using Fin.Domain.Entities;
using Fin.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fin.Repository
{
    public class TransactionRepository(FinContext dbContext) : ITransactionRepository
    {
        private readonly FinContext _dbContext = dbContext;

        public Task CreateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
