using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Classroom.Exceptions;
public class StudentNotFoundException : BusinessException
{
    public StudentNotFoundException(Guid id) : base($"no child with id = {id} was found")
    {
    }
}
