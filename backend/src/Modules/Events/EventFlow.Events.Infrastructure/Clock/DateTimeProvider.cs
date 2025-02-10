using EventFlow.Common.Application.Clock;

namespace EventFlow.Events.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
