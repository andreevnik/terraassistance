namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class ActivateProblemCommand : IRequest
{
    public ActivateProblemCommand(int problemId)
    {
        ProblemId = problemId;
    }

    public int ProblemId { get; }
}