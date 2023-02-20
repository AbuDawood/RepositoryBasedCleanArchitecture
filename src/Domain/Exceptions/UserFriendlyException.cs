namespace CleanArchitecture.Domain.Common;

public abstract class UserFriendlyException : Exception, IUserFriendlyException
{

    public UserFriendlyException(string friendlyMessage) : base()
    {
        FriendlyMessage = friendlyMessage;
    }

    public UserFriendlyException(string firendlyMessage,string message) : base(message)
    {
        FriendlyMessage = firendlyMessage;
    }

    public string FriendlyMessage { get; }
}
