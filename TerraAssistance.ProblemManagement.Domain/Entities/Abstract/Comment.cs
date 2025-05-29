namespace TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public abstract class Comment : Entity
{
    protected Comment(int id, string content, DateTime createdAt, int createdById)
    {
        Id = id;
        Content = content;
        CreatedAt = createdAt;
        CreatedById = createdById;
    }

    public string Content { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    public int CreatedById { get; set; }
}