using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Common.Application.Exceptions;

public sealed class EventFlowException(string requestName, Error? error = null, Exception? innerException = null)
    : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;

    public Error? Error { get; } = error;
}
