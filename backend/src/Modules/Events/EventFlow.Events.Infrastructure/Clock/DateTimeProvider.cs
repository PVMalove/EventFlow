using EventFlow.Events.Application.Abstractions.Clock;

namespace EventFlow.Events.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
