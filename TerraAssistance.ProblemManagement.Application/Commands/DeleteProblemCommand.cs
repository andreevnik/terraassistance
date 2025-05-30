namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class DeleteProblemCommand : IRequest
{
    public DeleteProblemCommand(int problemId)
    {
        ProblemId = problemId;
    }

    public int ProblemId { get; }
}