using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(Guid CustomerId) : ICommand;
