using Fin.Domain.Interfaces.CQRS.Commands;

namespace Fin.Domain.CQRS.Commands.CreateUser;
public class CreateUserCommand : ICommand
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
