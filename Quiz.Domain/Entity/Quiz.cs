using Quiz.Domain.Model;

namespace Quiz.Domain.Entity;

public class Quiz : EntityFactory
{
    public string? Name { get; set; }
    public int Fk_id_type_quiz { get; set; }
}
