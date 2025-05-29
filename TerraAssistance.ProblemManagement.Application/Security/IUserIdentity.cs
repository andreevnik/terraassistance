namespace TerraAssistance.ProblemManagement.Application.Security;

using TerraAssistance.ProblemManagement.Domain.Interfaces;

public interface IUserIdentity<TId> : IEntity<TId>
    where TId : struct, IEquatable<TId>
{
}

public interface IUserIdentity : IUserIdentity<int>
{
}