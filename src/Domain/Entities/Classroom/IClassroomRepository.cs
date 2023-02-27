using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Foundations.BaseRepositories;

namespace CleanArchitecture.Domain.Entities.Classroom;

public interface IClassroomRepository : IRepository<Classroom, Guid>
{
}
