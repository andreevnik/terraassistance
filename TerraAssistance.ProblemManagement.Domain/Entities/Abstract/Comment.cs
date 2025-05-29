namespace TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public abstract class Comment : Entity
{
    protected Comment(int id, string text, DateTime createdAt, int createdById)
    {
        Id = id;
        Text = text;
        CreatedAt = createdAt;
        CreatedById = createdById;
    }

    public string Text { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    public int CreatedById { get; set; }
}