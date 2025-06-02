namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class AddSpentTimeCommand : IRequest
{
    public AddSpentTimeCommand(int problemId, int hours)
    {
        ProblemId = problemId;
        Hours = hours;
    }

    public int ProblemId { get; }

    public int Hours { get; }
}