namespace Quiz.Domain.DTO;

public class QuizDTO: Entity.Quiz
{
    public string Type { get; set; }
    public string Level { get; set; }
    public List<QuestionDTO>? ListQuestions { get; set; }
}