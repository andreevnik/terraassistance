namespace TerraAssistance.ProblemManagement.Application.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TerraAssistance.ProblemManagement.Application.Commands;
using TerraAssistance.ProblemManagement.Application.Security;
using TerraAssistance.ProblemManagement.Domain.Entities;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public class AddProblemCommandHandler : IRequestHandler<AddProblemCommand>
{
    private readonly IProblemRepository _problemRepository;
    private readonly IUserIdentityAccessor _userIdentityAccessor;

    public AddProblemCommandHandler(
        IProblemRepository problemRepository,
        IUserIdentityAccessor userIdentityAccessor)
    {
        _problemRepository = problemRepository;
        _userIdentityAccessor = userIdentityAccessor;
    }

    public async Task Handle(AddProblemCommand request, CancellationToken cancellationToken)
    {
        var userIdentity = await _userIdentityAccessor.GetUserIdentityAsync(cancellationToken);

        var problem = new Problem(
            request.Title,
            request.Description,
            userIdentity.Id,
            request.EstimatedAt);

        _problemRepository.Add(problem);

        await _problemRepository.SaveChangesAsync(cancellationToken);
    }
}