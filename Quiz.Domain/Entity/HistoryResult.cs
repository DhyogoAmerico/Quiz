using Quiz.Domain.Model;

namespace Quiz.Domain.Entity;

public class HistoryResult : EntityFactory
{
    public int Fk_id_quiz { get; set; }
    public int Fk_id_user { get; set; }
    public double Punctuation { get; set; }
}
