using Fin.Domain.CQRS.Commands.CreateUser;
using Fin.Domain.Interfaces.CQRS.Commands;
using Fin.Domain.Interfaces.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Fin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public UserController(ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {

            var result = await _commandDispatcher.DispatchAsync(request, cancellationToken);

            return result ? Created() : StatusCode(500, "erro ao processar");
        }

    }
}
