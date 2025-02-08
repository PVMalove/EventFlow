using EventFlow.Events.Domain.Abstractions;

namespace EventFlow.Events.Domain.Events;

public sealed class EventCanceledDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
