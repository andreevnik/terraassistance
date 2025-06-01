namespace TerraAssistance.ProblemManagement.Application.Security;

public interface IUserIdentityAccessor
{
    Task<UserIdentity?> TryGetUserIdentityAsync(CancellationToken cancellationToken);

    async Task<UserIdentity> GetUserIdentityAsync(CancellationToken cancellationToken)
        => await TryGetUserIdentityAsync(cancellationToken)
            ?? throw new InvalidOperationException("User identity is not available.");
}