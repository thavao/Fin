using Fin.Domain.Entities;
using Fin.Domain.Interfaces;
using Fin.Domain.Interfaces.CQRS.Commands;

namespace Fin.Domain.CQRS.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private IUserRepository _repositorý;
        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repositorý = repository;
        }
        public async Task HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = new User { Name = command.Name, Email = command.Email, Password = command.Password };

                await _repositorý.CreateUserAsync(user);
            }
            catch (Exception ex) { 
            }
        }
    }
}
