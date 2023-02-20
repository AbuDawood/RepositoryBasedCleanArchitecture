using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Exceptions;


public class ForbiddenAccessException : Exception, IUserFriendlyException
{
    public ForbiddenAccessException(string? friendlyMessage = null) : base()
    {
        FriendlyMessage = friendlyMessage;
    }

    public string? FriendlyMessage { get; }
}
