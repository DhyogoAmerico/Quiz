using Quiz.Domain.DTO;
using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IQuizRepository
    {
        Task Insert(Entity.Quiz quiz, List<AnswerOptions> listAnswer);
        Task Update(Entity.Quiz quiz);
        Task Delete(int id);
        Task<List<Entity.Quiz>> Search(string search);
        Task<QuizDTO> Get(int id);
        Task<QuizDTO> GetByType(int id);
    }
}