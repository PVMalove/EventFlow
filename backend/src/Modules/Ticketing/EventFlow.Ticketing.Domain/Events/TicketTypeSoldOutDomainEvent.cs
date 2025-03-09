using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Ticketing.Domain.Events;

public sealed class TicketTypeSoldOutDomainEvent(Guid ticketTypeId) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
