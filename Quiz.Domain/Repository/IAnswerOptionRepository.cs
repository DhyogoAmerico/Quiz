using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IAnswerOptionRepository
    {
        Task<bool> GetCorrect(int id_answer);
        Task<List<AnswerOptions>> GetOptions(int id_question);
    }
}