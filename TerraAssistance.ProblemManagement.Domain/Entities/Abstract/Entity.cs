namespace TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

using TerraAssistance.ProblemManagement.Domain.Interfaces;

public abstract class Entity<TId> : IEntity<TId>
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; protected set; }

    object IEntity.Id => Id;
}

public abstract class Entity : Entity<int>
{
}