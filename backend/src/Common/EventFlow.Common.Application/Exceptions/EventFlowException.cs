using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Common.Application.Exceptions;

public sealed class EventFlowException : Exception
{
    public EventFlowException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
