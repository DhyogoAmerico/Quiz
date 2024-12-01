using Quiz.Domain.Entity;

namespace Quiz.Domain.Repository
{
    public interface IUserRepository
    {
        Task Insert(User user);
        Task<User> Login(string email, string password);
    }
}