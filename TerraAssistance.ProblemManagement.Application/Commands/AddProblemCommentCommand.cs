namespace TerraAssistance.ProblemManagement.Application.Commands;

using MediatR;

public class AddProblemCommentCommand : IRequest
{
    public AddProblemCommentCommand(
        int problemId,
        string text)
    {
        ProblemId = problemId;
        Text = text;
    }

    public int ProblemId { get; }

    public string Text { get; }
}