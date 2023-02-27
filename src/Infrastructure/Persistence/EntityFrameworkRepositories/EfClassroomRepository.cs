using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Classroom;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.EntityFrameworkRepositories;


internal class EfClassroomRepository : EntityFrameworkRepositories.Base.EfRepositoryBase<Classroom, Guid>, IClassroomRepository
{
    public EfClassroomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Classroom> WithDefaultDetails()
    {
        return this.GetQueryable()
            .Include(e => e.Students);
    }
}
