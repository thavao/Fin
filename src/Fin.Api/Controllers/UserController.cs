using Fin.Domain.Entities;
using Fin.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async void CreateUser()
        {
            var user = new User
            {
                Name = "Test",
                Email = "email@email",
                Password = "password",
            };

            await _userRepository.CreateUserAsync(user);
        }

    }
}
