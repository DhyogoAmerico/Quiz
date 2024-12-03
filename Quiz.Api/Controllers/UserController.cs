using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.Command.CommandUser;
using Quiz.Domain.ContractsCommand;
using Quiz.Domain.Entity;
using Quiz.Domain.Repository;

namespace Quiz.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<CommandResult> Insert([FromBody] CreateUserCommand createUserCommand)
        {
            User user = createUserCommand.ToUser();
            await _userRepository.Insert(user);

            return CommandResult.Send(true, true);
        }
    }
}