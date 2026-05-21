using Fin.Domain.Interfaces.CQRS.Commands;
using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.Interfaces;

public interface IDispatcher
{
    Task DispatchAsync(ICommand command, CancellationToken cancellationToken = default);
    Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
