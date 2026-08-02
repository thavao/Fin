using Fin.Data;
using Fin.Domain.Entities;
using Fin.Domain.Interfaces;

namespace Fin.Repository;

public class FinancialBookRepository(FinContext dbContext) : IFinancialBookRepository
{
    private readonly FinContext _dbContext = dbContext;

    public Task CreateFinancialBookAsync(FinancialBook financialBook)
    {
        throw new NotImplementedException();
    }
}
