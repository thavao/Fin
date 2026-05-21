using Fin.Domain.Interfaces;
using Fin.Domain.Interfaces.CQRS.Commands;
using Fin.Domain.Interfaces.CQRS.Queries;

namespace Fin.Domain;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task DispatchAsync(
        ICommand command,
        CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();

        var handlerType = typeof(ICommandHandler<>)
            .MakeGenericType(commandType);

        var handler = _serviceProvider.GetService(handlerType);
        if (handler is null)
            throw new InvalidOperationException(
                $"Nenhum handler encontrado para o command {commandType.Name}");

        var method = handlerType.GetMethod("HandleAsync");

        if (method is null)
            throw new InvalidOperationException(
                $"Método HandleAsync não encontrado no handler {handlerType.Name}");

        var result = method.Invoke(handler, new object[] { command, cancellationToken });

        if (result is not Task task)
            throw new InvalidOperationException(
                $"O método HandleAsync do handler {handlerType.Name} não retornou uma Task.");

        await task;
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
