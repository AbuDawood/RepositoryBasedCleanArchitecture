using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Exceptions;

public class NotFoundException : Exception, IUserFriendlyException
{
    public string? FriendlyMessage { get; }

    public NotFoundException(string? friendlyMessage = null)
        : base()
    {
        FriendlyMessage = friendlyMessage;
    }

    public NotFoundException(string message, string? friendlyMessage = null)
        : base(message)
    {
        FriendlyMessage = friendlyMessage;
    }

    public NotFoundException(string message, Exception innerException, string? friendlyMessage = null)
        : base(message, innerException)
    {
        FriendlyMessage = friendlyMessage;
    }

    public NotFoundException(string name, object key, string? friendlyMessage = null)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
        FriendlyMessage = friendlyMessage;
    }

}
