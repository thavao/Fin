using Fin.Domain.Entities;

namespace Fin.Domain.Interfaces;

public interface IFinancialBookRepository
{
    Task CreateFinancialBookAsync(FinancialBook financialBook);
}
