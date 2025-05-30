namespace TerraAssistance.ProblemManagement.Domain.Interfaces;

using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;

public interface IRepository<TId, TEntity>
    where TId : struct, IEquatable<TId>
    where TEntity : Entity<TId>
{
    Task<TEntity?> TryFindByIdAsync(TId id, CancellationToken cancellationToken);

    Task<TEntity> FindByIdAsync(TId id, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken);

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}

public interface IRepository<TEntity> : IRepository<int, TEntity>
    where TEntity : Entity
{
}