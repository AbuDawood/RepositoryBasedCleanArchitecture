using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Foundations.BaseRepositories;

/// <summary>
/// TO mark class as repository
/// </summary>
public interface IRepository
{

}

/// <summary>
/// repository for entities with single identifier
/// </summary>
/// <typeparam name="TEntity">db entity</typeparam>
/// <typeparam name="TKey">key of single identifier</typeparam>
public interface IRepository<TEntity, TKey> :
   IRepository<TEntity>,
   IReadOnlyRepository<TEntity>,
   IRepository,
   IReadOnlyRepository<TEntity, TKey>
   where TEntity : class, IBaseEntity<TKey>
{
    Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);
    Task DeleteManyAsync([NotNull] IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default);
}


/// <summary>
/// repository for entities without keys or with composite keys
/// </summary>
/// <typeparam name="TEntity">db entity</typeparam>
public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>, IRepository where TEntity : class, IBaseEntity
{
    Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

    Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);


    Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);


    Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

    Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
}
