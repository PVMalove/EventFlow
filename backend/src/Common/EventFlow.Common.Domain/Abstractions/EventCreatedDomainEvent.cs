namespace EventFlow.Common.Domain.Abstractions;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}