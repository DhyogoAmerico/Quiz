using Quiz.Domain.Model;

namespace Quiz.Domain.Entity;

public class TypeQuiz : EntityFactory
{
    public string? Type { get; set; }
    public string? Level { get; set; }
}
