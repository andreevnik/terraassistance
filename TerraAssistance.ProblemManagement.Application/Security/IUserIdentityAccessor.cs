namespace TerraAssistance.ProblemManagement.Application.Security;

public interface IUserIdentityAccessor<TId>
    where TId : struct, IEquatable<TId>
{
    Task<IUserIdentity<TId>?> TryFindUserIdentityAsync(TId userId);

    async Task<IUserIdentity<TId>> FindUserIdentityAsync(TId userId)
        => await TryFindUserIdentityAsync(userId)
            ?? throw new InvalidOperationException($"User identity with ID {userId} not found.");
}

public interface IUserIdentityAccessor : IUserIdentity<int>
{
}