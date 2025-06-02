namespace TerraAssistance.ProblemManagement.Application.CommandHandlers;

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TerraAssistance.ProblemManagement.Application.Commands;
using TerraAssistance.ProblemManagement.Application.Security;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public class AddSpentTimeCommandHandler : IRequestHandler<AddSpentTimeCommand>
{
    private readonly IProblemRepository _problemRepository;
    private readonly IUserIdentityAccessor _userIdentityAccessor;

    public AddSpentTimeCommandHandler(IProblemRepository problemRepository, IUserIdentityAccessor userIdentityAccessor)
    {
        _problemRepository = problemRepository;
        _userIdentityAccessor = userIdentityAccessor;
    }

    public async Task Handle(AddSpentTimeCommand request, CancellationToken cancellationToken)
    {
        var userIdentity = await _userIdentityAccessor.GetUserIdentityAsync(cancellationToken);
        var problem = await _problemRepository.FindByIdAsync(request.ProblemId, cancellationToken);

        if (problem.CreatedById != userIdentity.Id)
            throw new UnauthorizedAccessException("You do not have permission to add spent time to this problem.");

        problem.AddSpentTime(request.Hours);
        _problemRepository.Update(problem);
        await _problemRepository.SaveChangesAsync(cancellationToken);
    }
}