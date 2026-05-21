namespace Fin.Domain.Interfaces.CQRS.Commands;

public interface ICommandHandler<TCommand>
     where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}