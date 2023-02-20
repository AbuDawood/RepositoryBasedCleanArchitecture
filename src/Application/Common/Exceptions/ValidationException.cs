using CleanArchitecture.Domain.Common;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Common.Exceptions;

public class ValidationException : Exception, IUserFriendlyException
{
    public ValidationException(string? friendlyMessage = null)
        : base("One or more validation failures have occurred.")
    {
        FriendlyMessage = friendlyMessage;
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures, string? friendlyMessage = null)
        : this()
    {
        FriendlyMessage = friendlyMessage;
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }

    public string? FriendlyMessage { get; }
}
