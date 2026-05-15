using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain.CQRS.Dispatcher;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchAsync<TResult>(
        IQuery<TResult> query,
        CancellationToken cancellationToken = default)
    {
        var queryType = query.GetType();

        var handlerType = typeof(IQueryHandler<,>)
            .MakeGenericType(queryType, typeof(TResult));

        var handler = _serviceProvider.GetService(handlerType);

        if (handler is null)
            throw new InvalidOperationException(
                $"Nenhum handler encontrado para a query {queryType.Name}");

        var method = handlerType.GetMethod("HandleAsync");

        if (method is null)
            throw new InvalidOperationException(
                $"Método HandleAsync não encontrado no handler {handlerType.Name}");

        var result = method.Invoke(handler, new object[] { query, cancellationToken });

        if (result is not Task<TResult> taskResult)
            throw new InvalidOperationException(
                $"O handler {handlerType.Name} não retornou Task<{typeof(TResult).Name}>");

        return await taskResult;
    }
}