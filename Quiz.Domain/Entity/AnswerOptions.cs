using Quiz.Domain.Model;

namespace Quiz.Domain.Entity;

public class AnswerOptions : EntityFactory
{
    public string? Answer { get; set; }
    public bool Correct { get; set; }
    public int Fk_id_question { get; set; }
}
