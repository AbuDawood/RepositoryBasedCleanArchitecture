using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Foundations.BaseRepositories;
using Microsoft.EntityFrameworkCore;



namespace CleanArchitecture.Infrastructure.Persistence.EntityFrameworkRepositories.Base;




public abstract class EfReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IBaseEntity
{
    public EfReadOnlyRepositoryBase(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; }

    protected DbSet<TEntity> GetDbSet()
    {
        return DbContext.Set<TEntity>();
    }


    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        return await (includeDetails ? WithDefaultDetails() : GetDbSet()).FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        var entity = await FindAsync(predicate, includeDetails, cancellationToken);

        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(TEntity));
        }

        return entity;
    }

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        return await GetDbSet().LongCountAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return includeDetails
               ? await WithDefaultDetails().ToListAsync(cancellationToken)
               : await GetDbSet().ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return includeDetails
               ? await WithDefaultDetails().Where(predicate).ToListAsync(cancellationToken)
               : await GetDbSet().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var queryable = includeDetails ? WithDefaultDetails() : GetDbSet();
        return await queryable
            .OrderBy(sorting)
            .Skip(skipCount).Take(maxResultCount)
            .ToListAsync(cancellationToken);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return GetDbSet().AsQueryable();
    }

    public abstract IQueryable<TEntity> WithDefaultDetails();

    public virtual IQueryable<TEntity> WithDetails(params Expression<Func<TEntity, object>>[] propertySelectors)
    {
        return IncludeDetails(
            GetQueryable(),
            propertySelectors
        );
    }

    private static IQueryable<TEntity> IncludeDetails(
        IQueryable<TEntity> query,
        Expression<Func<TEntity, object>>[] propertySelectors)
    {
        if (propertySelectors == null && propertySelectors.Any())
        {
            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }
        }

        return query;
    }
}


public abstract class EfReadOnlyRepositoryBase<TEntity, TKey> : EfReadOnlyRepositoryBase<TEntity>, IReadOnlyRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
    protected EfReadOnlyRepositoryBase(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


    public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        var entity = await FindAsync(id, includeDetails, cancellationToken);

        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(TEntity), id);
        }

        return entity;
    }


    public virtual async Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        return includeDetails
            ? await WithDefaultDetails().OrderBy(e => e.Id).FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken)
            : await GetDbSet().FindAsync(new object[] { id }, cancellationToken);
    }
}
