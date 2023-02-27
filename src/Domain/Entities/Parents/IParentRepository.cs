using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Foundations.BaseRepositories;

namespace CleanArchitecture.Domain.Entities.Parents;
public interface IParentRepository : IRepository<Parent, Guid>
{
    Task<Child> FindChild(Guid id, CancellationToken cancellationToken = default);
}
