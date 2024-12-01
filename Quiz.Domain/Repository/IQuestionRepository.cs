using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IQuestionRepository
    {
        Task Delete(int id);
        Task<List<Questions>> Get(int id_quiz);
        Task<Questions> Insert(Questions questions);
    }
}