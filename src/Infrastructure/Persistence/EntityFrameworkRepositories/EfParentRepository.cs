using CleanArchitecture.Domain.Entities.Parents;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFrameworkRepositories;

internal class EfParentRepository : EntityFrameworkRepositories.Base.EfRepositoryBase<Parent, Guid>, IParentRepository
{
    public EfParentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Child> FindChild(Guid id, CancellationToken cancellationToken = default)
    {
        return this.DbContext.Children.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public override IQueryable<Parent> WithDefaultDetails()
    {
        return this.GetQueryable()
             .Include(e => e.Children);
    }
}
