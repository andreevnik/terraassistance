namespace TerraAssistance.ProblemManagement.Domain.Entities;

using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;
using TerraAssistance.ProblemManagement.Domain.Enums;

public class Problem : Entity
{
    private readonly List<ProblemComment> _comments = new ();

    public Problem(string title, string? description, int createdById, DateTime? estimatedAt)
        : this(default, createdById, 0, title, description, ProblemStatus.New, DateTime.UtcNow, estimatedAt, null, null)
    {
    }

    protected Problem(
        int id,
        int createdById,
        int spentTimeHours,
        string title,
        string? description,
        ProblemStatus status,
        DateTime createdAt,
        DateTime? estimatedAt,
        DateTime? closedAt,
        string? closeResolution)
    {
        Id = id;
        CreatedById = createdById;
        SpentTimeHours = spentTimeHours;
        Title = title;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
        EstimatedAt = estimatedAt;
        ClosedAt = closedAt;
        CloseResolution = closeResolution;
    }

    public int CreatedById { get; protected set; }

    public int SpentTimeHours { get; protected set; }

    public string Title { get; protected set; }

    public string? Description { get; protected set; }

    public ProblemStatus Status { get; protected set; }

    public DateTime CreatedAt { get; protected set; }

    public DateTime? EstimatedAt { get; protected set; }

    public DateTime? ClosedAt { get; protected set; }

    public string? CloseResolution { get; protected set; }

    public IReadOnlyCollection<ProblemComment> Comments => _comments.AsReadOnly();

    public void Activate()
    {
        if (Status != ProblemStatus.New)
            throw new InvalidOperationException("Only new problems can be activated.");

        Status = ProblemStatus.InProgress;
    }

    public void Close(string? resolution)
    {
        if (Status != ProblemStatus.InProgress)
            throw new InvalidOperationException("Only problems in progress can be resolved.");

        Status = ProblemStatus.Closed;
        ClosedAt = DateTime.UtcNow;
        CloseResolution = resolution;
    }

    public void AddSpentTime(int hours)
    {
        if (hours < 0)
            throw new ArgumentOutOfRangeException(nameof(hours), "Spent time cannot be negative.");

        SpentTimeHours += hours;
    }

    public void AddComment(string text, int createdById)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException("Comment content cannot be empty.", nameof(text));

        if (createdById <= 0)
            throw new ArgumentOutOfRangeException(nameof(createdById), "Created by ID must be a positive integer.");

        var comment = new ProblemComment(text, createdById);
        _comments.Add(comment);
    }
}