namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class AddProblemCommand : IRequest
{
    public AddProblemCommand(
        string title,
        string? description,
        DateTime? estimatedAt)
    {
        Title = title;
        Description = description;
        EstimatedAt = estimatedAt;
    }

    public string Title { get; }

    public string? Description { get; }

    public DateTime? EstimatedAt { get; }
}