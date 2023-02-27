using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Classroom.Exceptions;
public class ClassroomFullfilledException : BusinessException
{
    public ClassroomFullfilledException(string code) : base($"the classroom \"{code}\" is full filled")
    {
    }
}
