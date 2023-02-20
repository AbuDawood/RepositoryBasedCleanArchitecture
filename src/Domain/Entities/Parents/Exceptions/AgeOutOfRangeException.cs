using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Parents.Exceptions;
public class AgeOutOfRangeException : BusinessException
{
    public AgeOutOfRangeException(int age) : base($"the {age} years is out of allowed range")
    {
    }
}
