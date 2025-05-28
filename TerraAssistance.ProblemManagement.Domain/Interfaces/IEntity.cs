namespace TerraAssistance.ProblemManagement.Domain.Interfaces;

public interface IEntity
{
    object Id { get; }
}

public interface IEntity<TId> : IEntity
    where TId : struct, IEquatable<TId>
{
    new TId Id { get; }
}