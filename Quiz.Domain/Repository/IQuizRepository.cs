using Quiz.Domain.DTO;
using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IQuizRepository
    {
        Task Insert(Entity.Quiz quiz);
        Task Update(Entity.Quiz quiz);
        Task Delete(int id);
        Task<List<Entity.Quiz>> Search(string search);
        Task<QuizDTO> Get(int id);
        Task<IList<QuizDTO>> GetByType(int id_type);
        Task<IList<QuizDTO>> GetAll();
    }
}