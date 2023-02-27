using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Classroom.Exceptions;
public class StudentAlreadyRegisteredException : BusinessException
{
    public StudentAlreadyRegisteredException(string name, string code) : base($" the student \"{name}\" is already assigned to a classroom \"{code}\"")
    {
    }
}
