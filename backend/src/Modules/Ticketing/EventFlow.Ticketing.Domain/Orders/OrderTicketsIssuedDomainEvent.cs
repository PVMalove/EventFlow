using EventFlow.Common.Domain.Abstractions;

namespace EventFlow.Ticketing.Domain.Orders;

public sealed class OrderTicketsIssuedDomainEvent(Guid orderId) : DomainEvent
{
    public Guid OrderId { get; init; } = orderId;
}
