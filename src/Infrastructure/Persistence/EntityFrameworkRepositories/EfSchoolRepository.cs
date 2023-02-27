using CleanArchitecture.Domain.Entities.Schools;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFrameworkRepositories;

internal class EfSchoolRepository : EntityFrameworkRepositories.Base.EfRepositoryBase<School, Guid>, ISchoolRepository
{
    public EfSchoolRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<School> WithDefaultDetails()
    {
        return this.GetQueryable();
    }
}
