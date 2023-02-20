using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities.Parents.Exceptions;
internal class FirstnameNotAvailableException : BusinessException
{
    public FirstnameNotAvailableException(string firstname) : base($"the name {firstname} is not available")
    {
    }
}
