using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Ticketing.Domain.Events;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}
