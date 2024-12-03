using Quiz.Domain.Entity;

namespace Quiz.Domain.Service;

public interface ITokenService
{
    public abstract string Generate(User user);
}
