namespace CleanArchitecture.Domain.Common;

public interface IUserFriendlyException
{
    string FriendlyMessage { get; }
}
