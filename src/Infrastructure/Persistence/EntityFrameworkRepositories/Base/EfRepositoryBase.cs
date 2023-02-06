using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Foundations.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFrameworkRepositories.Base;

public abstract class EfRepositoryBase<TEntity> : EfReadOnlyRepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class, IBaseEntity
{

    public EfRepositoryBase(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    protected virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }


    public Task ExecuteDeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return GetDbSet().Where(predicate).ExecuteDeleteAsync(cancellationToken);
    }

    public Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        GetDbSet().Remove(entity);

        if (autoSave)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        return Task.CompletedTask;
    }

    public async Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        GetDbSet().RemoveRange(entities);

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        await GetDbSet().AddAsync(entity);

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }

        return entity;
    }

    public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        await GetDbSet().AddRangeAsync(entities);

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        DbContext.Attach(entity);

        var updatedEntity = DbContext.Update(entity).Entity;

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }

        return updatedEntity;
    }

    public async Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            await UpdateAsync(entity, cancellationToken: cancellationToken);
        }

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }

    //TODO-repository enhance the abstract representation for bulk update and add to IRepository
    public Task ExecuteUpdateAsync(Expression<Func<TEntity, bool>> predicate, Dictionary<Func<TEntity, object>, Func<TEntity, object>> propertiesSetter, CancellationToken cancellationToken = default)
    {
        //Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls = e =>
        //{
        //    foreach (var setter in propertiesSet)
        //        e.SetProperty(setter.Key, setter.Value);
        //    return e;
        //};

        //return GetDbSet()
        //.Where(predicate)
        //     .ExecuteUpdateAsync(setPropertyCalls, cancellationToken);

        throw new NotImplementedException();
    }
}

public abstract class EfRepositoryBase<TEntity, TKey> : EfRepositoryBase<TEntity>, IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
    protected EfRepositoryBase(ApplicationDbContext dbContext) : base(dbContext)
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


    public virtual async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        var entity = await FindAsync(id, cancellationToken: cancellationToken);
        if (entity == null)
        {
            return;
        }

        await DeleteAsync(entity, autoSave, cancellationToken);
    }

    public async Task DeleteManyAsync([NotNull] IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        foreach (var id in ids)
        {
            await DeleteAsync(id, cancellationToken: cancellationToken);
        }

        if (autoSave)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }
}
