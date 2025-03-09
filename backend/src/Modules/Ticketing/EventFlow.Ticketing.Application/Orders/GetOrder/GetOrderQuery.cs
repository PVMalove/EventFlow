using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Orders.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<OrderResponse>;
