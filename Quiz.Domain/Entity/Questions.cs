using Quiz.Domain.Model;

namespace Quiz.Domain.Entity;

public class Questions : EntityFactory
{
    public string? Question { get; set; }
    public int Fk_id_quiz { get; set; }
}
