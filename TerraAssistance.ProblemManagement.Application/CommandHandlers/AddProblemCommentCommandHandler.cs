namespace TerraAssistance.ProblemManagement.Application.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TerraAssistance.ProblemManagement.Application.Commands;
using TerraAssistance.ProblemManagement.Application.Security;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public class AddProblemCommentCommandHandler : IRequestHandler<AddProblemCommentCommand>
{
    private readonly IProblemRepository _problemRepository;
    private readonly IUserIdentityAccessor _userIdentityAccessor;

    public AddProblemCommentCommandHandler(
            IProblemRepository problemRepository,
            IUserIdentityAccessor userIdentityAccessor)
    {
        _problemRepository = problemRepository;
        _userIdentityAccessor = userIdentityAccessor;
    }

    public async Task Handle(AddProblemCommentCommand request, CancellationToken cancellationToken)
    {
        var userIdentity = await _userIdentityAccessor.GetUserIdentityAsync(cancellationToken);
        var problem = await _problemRepository.FindByIdAsync(request.ProblemId, cancellationToken);
        problem.AddComment(request.Text, userIdentity.Id);
        _problemRepository.Update(problem);
        await _problemRepository.SaveChangesAsync(cancellationToken);
    }
}