using Quiz.Domain.ContractsCommand;

namespace Quiz.Domain.Command.Quiz;

public class CreateOrUpdateQuiz : ICommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Fk_id_type_quiz { get; set; }
}
