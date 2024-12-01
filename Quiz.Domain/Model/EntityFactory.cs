using Quiz.Domain.Enum;

namespace Quiz.Domain.Model;

public abstract class EntityFactory
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public StatusEnum Status { get; set; } = StatusEnum.Active;
}
