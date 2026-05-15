using Fin.Domain.Interfaces.CQRS.Commands;

namespace Fin.Domain.CQRS.Dispatcher;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResult> DispatchAsync<TResult>(
        ICommand<TResult> command,
        CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();

        var handlerType = typeof(ICommandHandler<,>)
            .MakeGenericType(commandType, typeof(TResult));

        var handler = _serviceProvider.GetService(handlerType);

        if (handler is null)
            throw new InvalidOperationException(
                $"Nenhum handler encontrado para o command {commandType.Name}");

        var method = handlerType.GetMethod("HandleAsync");

        if (method is null)
            throw new InvalidOperationException(
                $"Método HandleAsync não encontrado no handler {handlerType.Name}");

        var result = method.Invoke(handler, new object[] { command, cancellationToken });

        if (result is not Task<TResult> taskResult)
            throw new InvalidOperationException(
                $"O handler {handlerType.Name} não retornou Task<{typeof(TResult).Name}>");

        return await taskResult;
    }
}