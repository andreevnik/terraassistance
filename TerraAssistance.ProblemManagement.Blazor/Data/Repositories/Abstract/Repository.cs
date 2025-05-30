namespace TerraAssistance.ProblemManagement.Blazor.Data.Repositories.Abstract;

using Microsoft.EntityFrameworkCore;
using TerraAssistance.ProblemManagement.Domain.Entities.Abstract;
using TerraAssistance.ProblemManagement.Domain.Interfaces;

public abstract class Repository<TEntity, TId> : IRepository<TId, TEntity>
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    protected ApplicationDbContext DbContext { get; }

    protected DbSet<TEntity> DbSet { get; }

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<TEntity?> TryFindByIdAsync(TId id, CancellationToken cancellationToken)
    {
        return await Query().SingleOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
    }

    public async Task<TEntity> FindByIdAsync(TId id, CancellationToken cancellationToken)
    {
        return await TryFindByIdAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Query().ToArrayAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    protected virtual IQueryable<TEntity> Query()
    {
        return DbSet;
    }
}

public abstract class Repository<TEntity> : Repository<TEntity, int>
    where TEntity : Entity<int>
{
    protected Repository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}