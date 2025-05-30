namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class CloseProblemCommand : IRequest
{
    public CloseProblemCommand(int problemId, string? resolution)
    {
        ProblemId = problemId;
        Resolution = resolution;
    }

    public int ProblemId { get; }

    public string? Resolution { get; }
}