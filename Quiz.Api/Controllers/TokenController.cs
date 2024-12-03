using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.ContractsCommand;
using Quiz.Domain.Model;
using Quiz.Domain.Repository;
using Quiz.Domain.Service;

namespace Quiz.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TokenController
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public TokenController(ITokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<CommandResult> Login([FromBody] AuthUser authUser)
    {
        var user = await _userRepository.Login(authUser.Email, authUser.Password);

        if (user is null)
        {
            return CommandResult.Send(false, null);
        }

        var token = _tokenService.Generate(user);

        return CommandResult.Send(true, token);
    }
}
