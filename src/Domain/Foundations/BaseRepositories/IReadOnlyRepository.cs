using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Foundations.BaseRepositories;


/// <summary>
/// repository for entities without keys or with composite keys
/// </summary>
/// <typeparam name="TEntity">db entity</typeparam>
public interface IReadOnlyRepository<TEntity> : IRepository where TEntity : class, IBaseEntity
{

    Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default(CancellationToken));

    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false, CancellationToken cancellationToken = default);

    Task<long> GetCountAsync(CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default);

    IQueryable<TEntity> WithDefaultDetails();

    IQueryable<TEntity> GetQueryable();

    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default);

}



/// <summary>
/// readonly repository for entities with single identifier
/// </summary>
/// <typeparam name="TEntity">db entity</typeparam>
/// <typeparam name="TKey">key of single identifier</typeparam>
public interface IReadOnlyRepository<TEntity, TKey> : IRepository where TEntity : class, IBaseEntity<TKey>
{
    Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
}
