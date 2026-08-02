using Fin.Api.Extensions;
using Fin.Domain.CQRS.Commands.CreateUser;
using Fin.Domain.CQRS.Queries.GetUserById;
using Fin.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public UserController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _dispatcher.DispatchAsync(request, cancellationToken);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _dispatcher.DispatchAsync(new GetUserByIdQuery { Id = id });
            return result.ToActionResult(this);
        }

    }
}
