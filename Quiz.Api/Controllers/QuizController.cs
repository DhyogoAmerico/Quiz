using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Domain.ContractsCommand;
using Quiz.Domain.Repository;

namespace Quiz.Api.Controllers;

[ApiController]
[Authorize]
[Route("/api/[controller]")]
public class QuizController
{
    private readonly IQuizRepository _quizRepository;

    public QuizController(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    [HttpPost]
    public async Task<CommandResult> Insert([FromBody] )
}
