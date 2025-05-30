namespace TerraAssistance.ProblemManagement.Application.Security;

public interface IUserIdentityAccessor<TId>
    where TId : struct, IEquatable<TId>
{
    Task<IUserIdentity<TId>?> TryGetUserIdentityAsync(CancellationToken cancellationToken);

    async Task<IUserIdentity<TId>> GetUserIdentityAsync(CancellationToken cancellationToken)
        => await TryGetUserIdentityAsync(cancellationToken)
            ?? throw new InvalidOperationException("User identity is not available.");
}

public interface IUserIdentityAccessor : IUserIdentityAccessor<int>
{
}