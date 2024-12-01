using Quiz.Domain.Model;
using Quiz.Domain.ValueType;

namespace Quiz.Domain.Entity;

public class User : EntityFactory
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Password Password { get; set; }
    public string? Phone { get; set; }
    public DateTime DateBirth { get; set; }
    public string? Token { get; set; }
}
