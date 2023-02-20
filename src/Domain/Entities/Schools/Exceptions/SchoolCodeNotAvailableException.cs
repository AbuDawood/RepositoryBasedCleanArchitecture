using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Schools.Exceptions;
public class SchoolCodeNotAvailableException : BusinessException
{
    public SchoolCodeNotAvailableException(string code) : base($" the code {code} is not available")
    {
    }
}
