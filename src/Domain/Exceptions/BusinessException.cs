using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common;
public class BusinessException : UserFriendlyException
{
    public BusinessException(string friendlyMessage) : base(friendlyMessage)
    {
    }

    public BusinessException(string friendlyMessage, string message) : base(friendlyMessage, message)
    {
    }
}
